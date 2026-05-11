'use strict';

const API = '';
const ROWS = 35;
let materials = [];
let actions = [];
let terms = [];
let editMode = false;
let isNewRecipe = false;

// Table index → actual weigh_type in database (matches old WebForms code)
const WEIGH_TYPE_MAP = [0, 1, 7, 3, 5, 8, 2, 6];
// tblWeigh0=炭黑(type0), tblWeigh1=油11(type1), tblWeigh2=油14(type7),
// tblWeigh3=粉料(type3), tblWeigh4=油12(type5), tblWeigh5=油15(type8),
// tblWeigh6=胶料(type2,no act_code), tblWeigh7=油13(type6)

const $ = id => document.getElementById(id);
const setStatus = (msg, loading) => {
    const el = $('statusIndicator');
    el.textContent = (loading ? '◌ ' : '● ') + msg;
    el.className = loading ? 'text-white small loading' : 'text-white small';
};

function showToast(msg, type = 'success') {
    $('toastTitle').textContent = type === 'success' ? 'Thành công' : 'Lỗi';
    $('toastBody').textContent = msg;
    const t = $('toast');
    t.className = 'toast show bg-' + (type === 'success' ? 'success' : 'danger') + ' text-white';
    setTimeout(() => { t.className = 'toast'; }, 3000);
}

async function api(path) {
    setStatus('Đang tải...', true);
    try {
        const res = await fetch(API + path);
        const data = await res.json();
        setStatus('Sẵn sàng', false);
        return data;
    } catch (e) {
        setStatus('Lỗi kết nối', false);
        console.error(e);
        return null;
    }
}

async function apiPost(path, body) {
    setStatus('Đang lưu...', true);
    try {
        const res = await fetch(API + path, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(body)
        });
        const data = await res.json();
        setStatus('Sẵn sàng', false);
        return data;
    } catch (e) {
        setStatus('Lỗi kết nối', false);
        console.error(e);
        return null;
    }
}

// Build weighing table rows
function buildWeighTable(tableId, weighType, data, noActCode) {
    const tbody = document.querySelector(`#${tableId} tbody`);
    tbody.innerHTML = '';
    const filtered = data.filter(r => String(r.weigh_type).trim() === String(weighType));

    for (let i = 0; i < ROWS; i++) {
        const row = filtered[i] || {};
        const tr = document.createElement('tr');
        if (noActCode) {
            tr.innerHTML = `
                <td>${i + 1}</td>
                <td><select class="child-name" ${editMode ? '' : 'disabled'}>
                    <option value=""></option>
                    ${materials.map(m => `<option ${m.code?.trim() === (row.child_name || '').trim() ? 'selected' : ''}>${m.code?.trim() || ''}</option>`).join('')}
                </select></td>
                <td><input type="text" class="child-code" value="${(row.child_code || '').trim()}" ${editMode ? '' : 'disabled'}></td>
                <td><input type="number" class="set-weight" value="${(row.set_weight || '').toString().trim()}" ${editMode ? '' : 'disabled'}></td>
                <td><input type="number" class="error-allow" value="${(row.error_allow || '').toString().trim()}" ${editMode ? '' : 'disabled'}></td>
            `;
        } else {
            tr.innerHTML = `
                <td>${i + 1}</td>
                <td><select class="act-code" ${editMode ? '' : 'disabled'}>
                    <option value="1"></option>
                    <option value="0" ${row.act_code == '0' ? 'selected' : ''}>称里-Cân</option>
                    <option value="2" ${row.act_code == '2' ? 'selected' : ''}>卸料-Xả</option>
                </select></td>
                <td><select class="child-name" ${editMode ? '' : 'disabled'}>
                    <option value=""></option>
                    ${materials.map(m => `<option ${m.code?.trim() === (row.child_name || '').trim() ? 'selected' : ''}>${m.code?.trim() || ''}</option>`).join('')}
                </select></td>
                <td><input type="text" class="child-code" value="${(row.child_code || '').trim()}" ${editMode ? '' : 'disabled'}></td>
                <td><input type="number" class="set-weight" value="${(row.set_weight || '').toString().trim()}" ${editMode ? '' : 'disabled'}></td>
                <td><input type="number" class="error-allow" value="${(row.error_allow || '').toString().trim()}" ${editMode ? '' : 'disabled'}></td>
            `;
        }
        tr.dataset.weightId = row.weight_id || (i + 1);
        tr.dataset.weighType = weighType;
        tbody.appendChild(tr);
    }
}

// Build mix table
function buildMixTable(data) {
    const tbody = document.querySelector('#tblMix tbody');
    tbody.innerHTML = '';

    for (let i = 0; i < ROWS; i++) {
        const row = data[i] || {};
        const tr = document.createElement('tr');
        tr.innerHTML = `
            <td>${i + 1}</td>
            <td><select class="mix-act" ${editMode ? '' : 'disabled'}>
                <option value=""></option>
                ${actions.map(a => `<option value="${a.act_code}" ${String(a.act_code).trim() === String(row.act_code || '').trim() ? 'selected' : ''}>${(a.act_name || '').trim()}</option>`).join('')}
            </select></td>
            <td><input type="number" class="set-time" value="${(row.set_time || '').toString().trim()}" ${editMode ? '' : 'disabled'}></td>
            <td><input type="number" class="set-temp" value="${(row.set_temp || '').toString().trim()}" ${editMode ? '' : 'disabled'}></td>
            <td><input type="number" class="set-power" value="${(row.set_power || '').toString().trim()}" ${editMode ? '' : 'disabled'}></td>
            <td><input type="number" class="set-ener" value="${(row.set_ener || '').toString().trim()}" ${editMode ? '' : 'disabled'}></td>
            <td><select class="term-code" ${editMode ? '' : 'disabled'}>
                <option value=""></option>
                ${terms.map(t => `<option value="${t.term_code}" ${String(t.term_code).trim() === String(row.term_code || '').trim() ? 'selected' : ''}>${(t.term_name || '').trim()}</option>`).join('')}
            </select></td>
            <td><input type="number" class="set-pres" value="${(row.set_pres || '').toString().trim()}" ${editMode ? '' : 'disabled'}></td>
            <td><input type="number" class="set-rota" value="${(row.set_rota || '').toString().trim()}" ${editMode ? '' : 'disabled'}></td>
        `;
        tbody.appendChild(tr);
    }
}

function setFormDisabled(disabled) {
    const fields = ['txtMaterCode', 'txtMaterName', 'txtMiniTemp', 'txtMaxTemp', 'cbRecipeType',
        'txtMiniTime', 'txtOverTemp', 'chkBlackReuse', 'txtReuseTime',
        'txtThreeTemp1', 'txtThreeTemp2', 'txtThreeTemp3', 'txtThreeTemp4',
        'txtTablettingTemp', 'chkEverUsed', 'txtTotalWeight', 'txtMemNote'];
    fields.forEach(id => { $(id).disabled = disabled; });
}

function clearForm() {
    $('txtMaterCode').value = '';
    $('txtMaterName').value = '';
    $('txtMiniTemp').value = '';
    $('txtMaxTemp').value = '';
    $('cbRecipeType').value = '';
    $('txtMiniTime').value = '';
    $('txtOverTemp').value = '';
    $('chkBlackReuse').checked = false;
    $('txtReuseTime').value = '';
    $('txtThreeTemp1').value = '';
    $('txtThreeTemp2').value = '';
    $('txtThreeTemp3').value = '';
    $('txtThreeTemp4').value = '';
    $('txtTablettingTemp').value = '';
    $('txtDefineDate').value = '';
    $('chkEverUsed').checked = false;
    $('txtTotalWeight').value = '';
    $('txtMemNote').value = '';
}

function fillForm(r) {
    if (!r) return;
    $('txtMaterCode').value = (r.mater_code || '').trim();
    $('txtMaterName').value = (r.mater_name || '').trim();
    $('txtMiniTemp').value = r.mini_temp || '';
    $('txtMaxTemp').value = r.max_temp || '';
    $('cbRecipeType').value = (r.RecipeType || '').toString().trim();
    $('txtMiniTime').value = r.mini_time || '';
    $('txtOverTemp').value = r.over_temp || '';
    $('chkBlackReuse').checked = r.black_reuse == 1;
    $('txtReuseTime').value = r.reuse_time || '';
    $('txtThreeTemp1').value = r.ThreeTemp1 || '';
    $('txtThreeTemp2').value = r.ThreeTemp2 || '';
    $('txtThreeTemp3').value = r.ThreeTemp3 || '';
    $('txtThreeTemp4').value = r.ThreeTemp4 || '';
    $('txtTablettingTemp').value = r.tablettingtemp || '';
    $('txtDefineDate').value = r.define_date || '';
    $('chkEverUsed').checked = r.ever_used == 1;
    $('txtMemNote').value = (r.mem_note || '').trim();
}

function enterEditMode(isNew) {
    editMode = true;
    isNewRecipe = isNew;
    setFormDisabled(false);
    if (!isNew) $('txtMaterCode').disabled = true;
    $('btnSave').classList.remove('d-none');
    $('btnCancel').classList.remove('d-none');
    $('btnAdd').disabled = true;
    $('btnEdit').disabled = true;
    $('btnCopy').disabled = true;
    // Rebuild tables in edit mode
    reloadCurrentData();
}

function exitEditMode() {
    editMode = false;
    isNewRecipe = false;
    setFormDisabled(true);
    $('btnSave').classList.add('d-none');
    $('btnCancel').classList.add('d-none');
    $('btnAdd').disabled = false;
    $('btnEdit').disabled = !$('cbKeo').value;
    $('btnCopy').disabled = !$('cbKeo').value;
    reloadCurrentData();
}

let currentWeighData = [];
let currentMixData = [];

function reloadCurrentData() {
    for (let i = 0; i < 8; i++) {
        const dbType = WEIGH_TYPE_MAP[i];
        const noActCode = (i === 6); // tblWeigh6 (胶料) has no act_code column
        buildWeighTable('tblWeigh' + i, dbType, currentWeighData, noActCode);
    }
    buildMixTable(currentMixData);
}

function collectWeighData() {
    const result = [];
    for (let tableIdx = 0; tableIdx < 8; tableIdx++) {
        const dbType = WEIGH_TYPE_MAP[tableIdx];
        const noActCode = (tableIdx === 6);
        const rows = document.querySelectorAll(`#tblWeigh${tableIdx} tbody tr`);
        rows.forEach((tr, idx) => {
            const actCodeEl = tr.querySelector('.act-code');
            const actCode = actCodeEl ? actCodeEl.value : '';
            const childName = tr.querySelector('.child-name').value;
            const childCode = tr.querySelector('.child-code').value;
            const setWeight = tr.querySelector('.set-weight').value;
            const errorAllow = tr.querySelector('.error-allow').value;
            if (noActCode) {
                if (childName) {
                    result.push({
                        weight_id: idx + 1,
                        child_name: childName,
                        child_code: childCode,
                        set_weight: setWeight || '0',
                        error_allow: errorAllow || '0',
                        weigh_type: String(dbType),
                        act_code: ''
                    });
                }
            } else {
                if (actCode !== '1' && (childName || setWeight)) {
                    result.push({
                        weight_id: idx + 1,
                        child_name: childName,
                        child_code: childCode,
                        set_weight: setWeight || '0',
                        error_allow: errorAllow || '0',
                        weigh_type: String(dbType),
                        act_code: actCode
                    });
                }
            }
        });
    }
    return result;
}

function collectMixData() {
    const result = [];
    const rows = document.querySelectorAll('#tblMix tbody tr');
    rows.forEach(tr => {
        const actCode = tr.querySelector('.mix-act').value;
        const setTime = tr.querySelector('.set-time').value;
        const setTemp = tr.querySelector('.set-temp').value;
        const setPower = tr.querySelector('.set-power').value;
        const setEner = tr.querySelector('.set-ener').value;
        const termCode = tr.querySelector('.term-code').value;
        const setPres = tr.querySelector('.set-pres').value;
        const setRota = tr.querySelector('.set-rota').value;
        if (actCode || setTime || setTemp) {
            result.push({
                act_code: actCode,
                set_time: setTime || '0',
                set_temp: setTemp || '0',
                set_ener: setEner || '0',
                set_power: setPower || '0',
                term_code: termCode || '0',
                set_pres: setPres || '0',
                set_rota: setRota || '0'
            });
        }
    });
    return result;
}

// Event: Machine changed
$('cbMay').addEventListener('change', async function () {
    const machine = this.value;
    $('cbKeo').innerHTML = '<option value="">-- Chọn keo --</option>';
    clearForm();
    currentWeighData = [];
    currentMixData = [];
    reloadCurrentData();

    if (!machine) {
        $('cbKeo').disabled = true;
        $('btnAdd').disabled = true;
        $('btnEdit').disabled = true;
        $('btnCopy').disabled = true;
        return;
    }

    // Load recipes and materials in parallel
    const [recipesData, materialsData] = await Promise.all([
        api(`/api/recipes?machine=${machine}`),
        api(`/api/materials?machine=${machine}`)
    ]);

    if (materialsData) {
        materials = materialsData.materials || [];
        actions = materialsData.actions || [];
        terms = materialsData.terms || [];
    }

    if (recipesData) {
        recipesData.forEach(r => {
            const opt = document.createElement('option');
            opt.value = (r.mater_code || '').trim();
            opt.textContent = (r.mater_code || '').trim();
            $('cbKeo').appendChild(opt);
        });
    }

    $('cbKeo').disabled = false;
    $('btnAdd').disabled = false;
    reloadCurrentData();
});

// Event: Recipe selected
$('cbKeo').addEventListener('change', async function () {
    const keo = this.value;
    const machine = $('cbMay').value;

    if (!keo || !machine) {
        clearForm();
        currentWeighData = [];
        currentMixData = [];
        reloadCurrentData();
        $('btnEdit').disabled = true;
        $('btnCopy').disabled = true;
        return;
    }

    const data = await api(`/api/recipe?machine=${machine}&keo=${encodeURIComponent(keo)}`);
    if (data) {
        if (data.recipe && data.recipe.length > 0) {
            fillForm(data.recipe[0]);
        }
        currentWeighData = data.weigh || [];
        currentMixData = data.mix || [];
        reloadCurrentData();
        $('btnEdit').disabled = false;
        $('btnCopy').disabled = false;
    }
});

// Event: Add new
$('btnAdd').addEventListener('click', function () {
    clearForm();
    currentWeighData = [];
    currentMixData = [];
    enterEditMode(true);
    $('txtMaterCode').disabled = false;
    $('txtMaterCode').focus();
});

// Event: Edit
$('btnEdit').addEventListener('click', function () {
    enterEditMode(false);
});

// Event: Cancel
$('btnCancel').addEventListener('click', function () {
    exitEditMode();
    // Reload current recipe
    $('cbKeo').dispatchEvent(new Event('change'));
});

// Event: Save
$('btnSave').addEventListener('click', async function () {
    const machine = $('cbMay').value;
    const mater_code = $('txtMaterCode').value.trim();
    if (!mater_code) {
        showToast('Vui lòng nhập mã phối phương!', 'error');
        return;
    }
    if (!machine) {
        showToast('Vui lòng chọn máy!', 'error');
        return;
    }

    const body = {
        machine,
        isNew: isNewRecipe,
        mater_code,
        mater_name: $('txtMaterName').value.trim(),
        mini_temp: $('txtMiniTemp').value || '0',
        max_temp: $('txtMaxTemp').value || '0',
        recipe_type: $('cbRecipeType').value,
        mini_time: $('txtMiniTime').value || '0',
        over_temp: $('txtOverTemp').value || '0',
        black_reuse: $('chkBlackReuse').checked,
        reuse_time: $('txtReuseTime').value || '0',
        three_temp1: $('txtThreeTemp1').value || '0',
        three_temp2: $('txtThreeTemp2').value || '0',
        three_temp3: $('txtThreeTemp3').value || '0',
        three_temp4: $('txtThreeTemp4').value || '0',
        tabletting_temp: $('txtTablettingTemp').value || '0',
        ever_used: $('chkEverUsed').checked,
        total_weight: $('txtTotalWeight').value || '0',
        mem_note: $('txtMemNote').value,
        weighData: collectWeighData(),
        mixData: collectMixData()
    };

    const result = await apiPost('/api/recipe/save', body);
    if (result && result.success) {
        showToast(result.message);
        exitEditMode();
        // Reload recipe list
        $('cbMay').dispatchEvent(new Event('change'));
    } else {
        showToast(result?.message || 'Lỗi khi lưu!', 'error');
    }
});

// Event: Copy
$('btnCopy').addEventListener('click', function () {
    const modal = new bootstrap.Modal($('copyModal'));
    const currentKeo = $('cbKeo').value;
    $('txtCopyCode').value = currentKeo;
    $('txtCopyName').value = currentKeo;
    document.querySelectorAll('.copy-machine').forEach(cb => cb.checked = false);
    modal.show();
});

$('btnCopyConfirm').addEventListener('click', async function () {
    const targetCode = $('txtCopyCode').value.trim();
    const targetName = $('txtCopyName').value.trim();
    if (!targetCode) {
        showToast('Vui lòng nhập mã vật liệu!', 'error');
        return;
    }
    const selectedMachines = [];
    document.querySelectorAll('.copy-machine:checked').forEach(cb => {
        selectedMachines.push(cb.value);
    });
    if (selectedMachines.length === 0) {
        showToast('Vui lòng chọn ít nhất 1 máy!', 'error');
        return;
    }

    const sourceMachine = $('cbMay').value;
    const sourceKeo = $('cbKeo').value;

    const result = await apiPost('/api/recipe/copy', {
        source_machine: sourceMachine,
        source_keo: sourceKeo,
        target_code: targetCode,
        target_name: targetName,
        target_machines: selectedMachines
    });

    if (result && result.success) {
        showToast(result.message);
        bootstrap.Modal.getInstance($('copyModal')).hide();
        $('cbMay').dispatchEvent(new Event('change'));
    } else {
        showToast(result?.message || 'Lỗi!', 'error');
    }
});

// Initial state
reloadCurrentData();
