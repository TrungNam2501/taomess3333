using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseStaticFiles();

var machineIPs = new Dictionary<string, string>
{
    ["01"] = "198.1.8.21",
    ["02"] = "198.1.8.22",
    ["03"] = "198.1.8.23",
    ["04"] = "198.1.8.24",
    ["05"] = "198.1.8.35",
    ["06"] = "198.1.8.36",
    ["07"] = "198.1.8.37",
    ["08"] = "198.1.8.38"
};

string GetConnectionString(string ip, string catalog = "mfns")
{
    return $"Data Source={ip};Initial Catalog={catalog};User ID=kendakv2;Password=kenda123;TrustServerCertificate=True;Connect Timeout=5";
}

async Task<List<Dictionary<string, object?>>> QueryAsync(string ip, string sql, string catalog = "mfns")
{
    var results = new List<Dictionary<string, object?>>();
    try
    {
        await using var conn = new SqlConnection(GetConnectionString(ip, catalog));
        await conn.OpenAsync();
        await using var cmd = new SqlCommand(sql, conn);
        cmd.CommandTimeout = 10;
        await using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var row = new Dictionary<string, object?>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
            }
            results.Add(row);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"DB Error: {ex.Message}");
    }
    return results;
}

async Task<int> ExecuteAsync(string ip, string sql, string catalog = "mfns")
{
    try
    {
        await using var conn = new SqlConnection(GetConnectionString(ip, catalog));
        await conn.OpenAsync();
        await using var cmd = new SqlCommand(sql, conn);
        cmd.CommandTimeout = 10;
        return await cmd.ExecuteNonQueryAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"DB Error: {ex.Message}");
        return -1;
    }
}

// GET /api/machines - list available machines
app.MapGet("/api/machines", () =>
{
    var machines = machineIPs.Select(kv => new { code = kv.Key, name = $"V-BB370{kv.Key}", ip = kv.Value });
    return Results.Ok(machines);
});

// GET /api/recipes?machine=01 - get recipe list for a machine
app.MapGet("/api/recipes", async (string machine) =>
{
    if (!machineIPs.TryGetValue(machine, out var ip))
        return Results.BadRequest("Invalid machine code");

    var sql = "SELECT LTRIM(RTRIM(mater_code)) AS mater_code FROM [mfns].[dbo].[pmt_recipe]";
    var data = await QueryAsync(ip, sql);
    return Results.Ok(data);
});

// GET /api/recipe?machine=01&keo=XXX - get full recipe detail
app.MapGet("/api/recipe", async (string machine, string keo) =>
{
    if (!machineIPs.TryGetValue(machine, out var ip))
        return Results.BadRequest("Invalid machine code");

    var recipeSql = $"SELECT [mater_code],[mater_name],mini_temp,max_temp,RecipeType,mini_time,over_temp,black_reuse,reuse_time,ThreeTemp1,ThreeTemp2,ThreeTemp3,ThreeTemp4,tablettingtemp,define_date,ever_used,mem_note FROM [pmt_recipe] WHERE mater_code='{keo.Replace("'", "''")}'";
    var recipe = await QueryAsync(ip, recipeSql);

    var weighSql = $"SELECT weight_id, child_name, child_code, set_weight, error_allow, weigh_type, act_code FROM [pmt_weigh] WHERE father_code='{keo.Replace("'", "''")}'";
    var weigh = await QueryAsync(ip, weighSql);

    var mixSql = $"SELECT mix_id, act_code, set_time, set_temp, set_ener, set_power, term_code, set_pres, set_rota FROM pmt_mix WHERE father_code='{keo.Replace("'", "''")}'";
    var mix = await QueryAsync(ip, mixSql);

    return Results.Ok(new { recipe, weigh, mix });
});

// GET /api/materials?machine=01 - get material list for dropdowns
app.MapGet("/api/materials", async (string machine) =>
{
    if (!machineIPs.TryGetValue(machine, out var ip))
        return Results.BadRequest("Invalid machine code");

    var materialSql = "SELECT mater_name AS code FROM [mfns].[dbo].[pmt_material]";
    var materials = await QueryAsync(ip, materialSql);

    var actSql = @"SELECT [act_code],
        CASE
            WHEN RTRIM(act_name) = N'加胶' THEN RTRIM(act_name)+N' - Thêm cao su'
            WHEN RTRIM(act_name) = N'降上顶栓' THEN RTRIM(act_name)+N' - Búa xuống'
            WHEN RTRIM(act_name) = N'开卸料门' THEN RTRIM(act_name)+N' - Mở cửa xả liệu'
            WHEN RTRIM(act_name) = N'保持' THEN RTRIM(act_name)+N' - Duy trì'
            WHEN RTRIM(act_name) = N'升上顶栓' THEN RTRIM(act_name)+N' - Búa lên'
            WHEN RTRIM(act_name) = N'开加料门' THEN RTRIM(act_name)+N' - Mở cửa vào liệu'
            WHEN RTRIM(act_name) = N'加油3' THEN RTRIM(act_name)+N' - Thêm dầu 3'
            WHEN RTRIM(act_name) = N'上顶栓中到位' THEN RTRIM(act_name)+N' - Búa lên giữa'
            WHEN RTRIM(act_name) = N'上顶栓浮动' THEN RTRIM(act_name)+N' - Búa nhấp nhô'
            WHEN RTRIM(act_name) = N'加油4' THEN RTRIM(act_name)+N' - Thêm dầu 4'
            WHEN RTRIM(act_name) = N'关卸料门' THEN RTRIM(act_name)+N' - Đóng cửa xả liệu'
            WHEN RTRIM(act_name) = N'加油2' THEN RTRIM(act_name)+N' - Thêm dầu 2'
            WHEN RTRIM(act_name) = N'关加料门' THEN RTRIM(act_name)+N' - Đóng cửa vào liệu'
            WHEN RTRIM(act_name) = N'加油5' THEN RTRIM(act_name)+N' - Thêm dầu 5'
            WHEN RTRIM(act_name) = N'加炭黑' THEN RTRIM(act_name)+N' - Thêm Carbon'
            WHEN RTRIM(act_name) = N'加油1' THEN RTRIM(act_name)+N' - Thêm dầu 1'
            WHEN RTRIM(act_name) = N'加粉料' THEN RTRIM(act_name)+N' - Thêm bột'
            WHEN RTRIM(act_name) = N'加小药' THEN RTRIM(act_name)+N' - Thêm ít bột'
            ELSE act_name
        END AS act_name
        FROM [mfns].[dbo].[pmt_act]";
    var actions = await QueryAsync(ip, actSql);

    var termSql = @"SELECT [term_code],
        CASE
            WHEN term_code = 1 THEN RTRIM(term_name)+N' - Thời gian'
            WHEN term_code = 2 THEN RTRIM(term_name)+N' - Nhiệt độ'
            WHEN term_code = 3 THEN RTRIM(term_name)+N' - Năng lượng'
            WHEN term_code = 4 THEN RTRIM(term_name)+N' - Thời gian + Nhiệt độ'
            WHEN term_code = 5 THEN RTRIM(term_name)+N' - Thời gian + Năng lượng'
            WHEN term_code = 6 THEN RTRIM(term_name)+N' - Nhiệt độ + Năng lượng'
            WHEN term_code = 7 THEN RTRIM(term_name)+N' - Thời gian hoặc Nhiệt độ + Năng lượng'
            WHEN term_code = 8 THEN RTRIM(term_name)+N' - Thời gian hoặc Năng lượng + Nhiệt độ'
            WHEN term_code = 9 THEN RTRIM(term_name)+N' - Nhiệt độ hoặc Năng lượng + Thời gian'
            WHEN term_code = 10 THEN RTRIM(term_name)+N' - Thời gian + Nhiệt độ + Năng lượng'
            WHEN term_code = 11 THEN RTRIM(term_name)+N' - Thực hiện đồng thời'
            WHEN term_code = 12 THEN RTRIM(term_name)+N' - Hoàn thành phối phương'
            WHEN term_code = 13 THEN RTRIM(term_name)+N' - Thời gian hoặc Nhiệt độ'
            ELSE term_name
        END AS term_name
        FROM [mfns].[dbo].[pmt_term]";
    var terms = await QueryAsync(ip, termSql);

    return Results.Ok(new { materials, actions, terms });
});

// POST /api/recipe/save - save or update recipe
app.MapPost("/api/recipe/save", async (HttpRequest request) =>
{
    var body = await JsonSerializer.DeserializeAsync<JsonElement>(request.Body);
    var machine = body.GetProperty("machine").GetString()!;
    var isNew = body.GetProperty("isNew").GetBoolean();

    if (!machineIPs.TryGetValue(machine, out var ip))
        return Results.BadRequest("Invalid machine code");

    var mater_code = body.GetProperty("mater_code").GetString()?.Replace("'", "''") ?? "";
    var mater_name = body.GetProperty("mater_name").GetString()?.Replace("'", "''") ?? "";
    var mini_temp = body.GetProperty("mini_temp").GetString() ?? "0";
    var max_temp = body.GetProperty("max_temp").GetString() ?? "0";
    var recipe_type = body.GetProperty("recipe_type").GetString() ?? "";
    var mini_time = body.GetProperty("mini_time").GetString() ?? "0";
    var over_temp = body.GetProperty("over_temp").GetString() ?? "0";
    var black_reuse = body.GetProperty("black_reuse").GetBoolean() ? "1" : "0";
    var reuse_time = body.GetProperty("reuse_time").GetString() ?? "0";
    var three_temp1 = body.GetProperty("three_temp1").GetString() ?? "0";
    var three_temp2 = body.GetProperty("three_temp2").GetString() ?? "0";
    var three_temp3 = body.GetProperty("three_temp3").GetString() ?? "0";
    var three_temp4 = body.GetProperty("three_temp4").GetString() ?? "0";
    var tabletting_temp = body.GetProperty("tabletting_temp").GetString() ?? "0";
    var ever_used = body.GetProperty("ever_used").GetBoolean() ? "1" : "0";
    var mem_note = body.GetProperty("mem_note").GetString()?.Replace("'", "''") ?? "";
    var total_weight = body.GetProperty("total_weight").GetString() ?? "0";

    string recipeSql;
    if (isNew)
    {
        recipeSql = $@"INSERT INTO [pmt_recipe] (mater_code, mater_name, mini_temp, max_temp, RecipeType, mini_time, over_temp, black_reuse, reuse_time, ThreeTemp1, ThreeTemp2, ThreeTemp3, ThreeTemp4, tablettingtemp, define_date, ever_used, mem_note)
            VALUES ('{mater_code}','{mater_name}',{mini_temp},{max_temp},'{recipe_type}',{mini_time},{over_temp},{black_reuse},{reuse_time},{three_temp1},{three_temp2},{three_temp3},{three_temp4},{tabletting_temp},GETDATE(),{ever_used},'{mem_note}')";
    }
    else
    {
        recipeSql = $@"UPDATE [pmt_recipe] SET mater_name='{mater_name}', mini_temp={mini_temp}, max_temp={max_temp}, RecipeType='{recipe_type}', mini_time={mini_time}, over_temp={over_temp}, black_reuse={black_reuse}, reuse_time={reuse_time}, ThreeTemp1={three_temp1}, ThreeTemp2={three_temp2}, ThreeTemp3={three_temp3}, ThreeTemp4={three_temp4}, tablettingtemp={tabletting_temp}, define_date=GETDATE(), ever_used={ever_used}, mem_note='{mem_note}'
            WHERE mater_code='{mater_code}'";
    }

    // Delete old weight and mix data then re-insert
    var delWeigh = $"DELETE FROM [pmt_weigh] WHERE father_code='{mater_code}'";
    var delMix = $"DELETE FROM pmt_mix WHERE father_code='{mater_code}'";
    await ExecuteAsync(ip, delWeigh);
    await ExecuteAsync(ip, delMix);

    var result = await ExecuteAsync(ip, recipeSql);

    // Insert weight data
    if (body.TryGetProperty("weighData", out var weighArr))
    {
        foreach (var w in weighArr.EnumerateArray())
        {
            var wid = w.GetProperty("weight_id").GetString() ?? "0";
            var childName = w.GetProperty("child_name").GetString()?.Replace("'", "''") ?? "";
            var childCode = w.GetProperty("child_code").GetString()?.Replace("'", "''") ?? "";
            var setWeight = w.GetProperty("set_weight").GetString() ?? "0";
            var errorAllow = w.GetProperty("error_allow").GetString() ?? "0";
            var weighType = w.GetProperty("weigh_type").GetString() ?? "0";
            var actCode = w.GetProperty("act_code").GetString() ?? "0";

            if (string.IsNullOrWhiteSpace(childName) && actCode == "0") continue;
            if (setWeight == "") setWeight = "0";
            if (errorAllow == "") errorAllow = "0";

            var insSql = $"INSERT INTO [pmt_weigh] VALUES({wid},'{mater_code}','{machine}','6','{weighType}','{actCode}','{childCode}','{childName}',{setWeight},{errorAllow},null,null)";
            await ExecuteAsync(ip, insSql);
        }
    }

    // Insert mix data
    if (body.TryGetProperty("mixData", out var mixArr))
    {
        int mixId = 1;
        foreach (var m in mixArr.EnumerateArray())
        {
            var actCode = m.GetProperty("act_code").GetString() ?? "";
            var setTime = m.GetProperty("set_time").GetString() ?? "0";
            var setTemp = m.GetProperty("set_temp").GetString() ?? "0";
            var setEner = m.GetProperty("set_ener").GetString() ?? "0";
            var setPower = m.GetProperty("set_power").GetString() ?? "0";
            var termCode = m.GetProperty("term_code").GetString() ?? "0";
            var setPres = m.GetProperty("set_pres").GetString() ?? "0";
            var setRota = m.GetProperty("set_rota").GetString() ?? "0";

            if (string.IsNullOrWhiteSpace(actCode) && setTime == "0" && setTemp == "0") continue;

            if (setTime == "") setTime = "0";
            if (setTemp == "") setTemp = "0";
            if (setEner == "") setEner = "0";
            if (setPower == "") setPower = "0";
            if (setPres == "") setPres = "0";
            if (setRota == "") setRota = "0";

            var insSql = $"INSERT INTO pmt_mix VALUES({mixId},'{mater_code}','{machine}','{actCode}',{setTime},{setTemp},{setEner},{setPower},{termCode},{setPres},{setRota})";
            await ExecuteAsync(ip, insSql);
            mixId++;
        }
    }

    return result >= 0 ? Results.Ok(new { success = true, message = "Lưu thành công!" }) : Results.Ok(new { success = false, message = "Lỗi khi lưu!" });
});

// POST /api/recipe/copy - copy recipe to multiple target machines
app.MapPost("/api/recipe/copy", async (HttpRequest request) =>
{
    var body = await JsonSerializer.DeserializeAsync<JsonElement>(request.Body);
    var sourceMachine = body.GetProperty("source_machine").GetString()!;
    var sourceKeo = body.GetProperty("source_keo").GetString()!.Replace("'", "''");
    var targetCode = body.GetProperty("target_code").GetString()!.Replace("'", "''");
    var targetName = body.GetProperty("target_name").GetString()!.Replace("'", "''");
    var targetMachines = body.GetProperty("target_machines");

    if (!machineIPs.TryGetValue(sourceMachine, out var sourceIp))
        return Results.BadRequest("Invalid source machine code");

    // Read source data once
    var recipeData = await QueryAsync(sourceIp, $"SELECT mini_temp,max_temp,RecipeType,mini_time,over_temp,black_reuse,reuse_time,ThreeTemp1,ThreeTemp2,ThreeTemp3,ThreeTemp4,tablettingtemp,ever_used,mem_note FROM [pmt_recipe] WHERE mater_code='{sourceKeo}'");
    var weighData = await QueryAsync(sourceIp, $"SELECT weight_id,scale_code,weigh_type,act_code,child_code,child_name,set_weight,error_allow FROM [pmt_weigh] WHERE father_code='{sourceKeo}'");
    var mixData = await QueryAsync(sourceIp, $"SELECT mix_id,act_code,set_time,set_temp,set_ener,set_power,term_code,set_pres,set_rota FROM pmt_mix WHERE father_code='{sourceKeo}'");

    if (recipeData.Count == 0)
        return Results.Ok(new { success = false, message = "Không tìm thấy recipe nguồn!" });

    var r = recipeData[0];
    int successCount = 0;

    foreach (var tm in targetMachines.EnumerateArray())
    {
        var targetMachineCode = tm.GetString()!;
        if (!machineIPs.TryGetValue(targetMachineCode, out var targetIp))
            continue;

        // Delete existing target recipe if exists
        await ExecuteAsync(targetIp, $"DELETE FROM [pmt_recipe] WHERE mater_code='{targetCode}'");
        await ExecuteAsync(targetIp, $"DELETE FROM [pmt_weigh] WHERE father_code='{targetCode}'");
        await ExecuteAsync(targetIp, $"DELETE FROM pmt_mix WHERE father_code='{targetCode}'");

        // Insert recipe
        var memNote = (r["mem_note"]?.ToString() ?? "").Replace("'", "''");
        var insRecipe = $@"INSERT INTO [pmt_recipe] (mater_code,mater_name,mini_temp,max_temp,RecipeType,mini_time,over_temp,black_reuse,reuse_time,ThreeTemp1,ThreeTemp2,ThreeTemp3,ThreeTemp4,tablettingtemp,define_date,ever_used,mem_note)
            VALUES('{targetCode}','{targetName}',{r["mini_temp"] ?? 0},{r["max_temp"] ?? 0},{r["RecipeType"] ?? 0},{r["mini_time"] ?? 0},{r["over_temp"] ?? 0},{r["black_reuse"] ?? 0},{r["reuse_time"] ?? 0},{r["ThreeTemp1"] ?? 0},{r["ThreeTemp2"] ?? 0},{r["ThreeTemp3"] ?? 0},{r["ThreeTemp4"] ?? 0},{r["tablettingtemp"] ?? 0},GETDATE(),{r["ever_used"] ?? 0},'{memNote}')";
        await ExecuteAsync(targetIp, insRecipe);

        // Insert weigh data
        foreach (var w in weighData)
        {
            var childCode = (w["child_code"]?.ToString() ?? "").Replace("'", "''");
            var childName = (w["child_name"]?.ToString() ?? "").Replace("'", "''");
            var insWeigh = $@"INSERT INTO [pmt_weigh] VALUES({w["weight_id"]},'{targetCode}','{targetMachineCode}','{w["scale_code"]}','{w["weigh_type"]}','{w["act_code"]}','{childCode}','{childName}',{w["set_weight"] ?? 0},{w["error_allow"] ?? 0},null,null)";
            await ExecuteAsync(targetIp, insWeigh);
        }

        // Insert mix data
        foreach (var m in mixData)
        {
            var insMix = $@"INSERT INTO pmt_mix VALUES({m["mix_id"]},'{targetCode}','{targetMachineCode}','{m["act_code"]}',{m["set_time"] ?? 0},{m["set_temp"] ?? 0},{m["set_ener"] ?? 0},{m["set_power"] ?? 0},{m["term_code"] ?? 0},{m["set_pres"] ?? 0},{m["set_rota"] ?? 0})";
            await ExecuteAsync(targetIp, insMix);
        }

        successCount++;
    }

    return Results.Ok(new { success = successCount > 0, message = $"Copy thành công sang {successCount} máy!" });
});

app.MapFallbackToFile("index.html");

app.Run();
