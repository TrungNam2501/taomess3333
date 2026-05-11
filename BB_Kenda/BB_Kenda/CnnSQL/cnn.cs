using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BB_Kenda.CnnSQL
{
    public class cnn
    {
        public static DataTable ExecuteQuery33bb(string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=198.1.10.33;Failover Partner =198.1.10.31;Initial Catalog=BB;User ID=kendakv2;Password=kenda123";
           ;
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static bool ExecuteNonQuery33bb(string query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=198.1.10.33;Failover Partner =198.1.10.31;Initial Catalog=BB;User ID=kendakv2;Password=kenda123";

            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    int effectedRow = cmd.ExecuteNonQuery();
                    return effectedRow > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }


        public static DataTable ExecuteQuery33(string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=198.1.10.33;Failover Partner =198.1.10.31;Initial Catalog=erp;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = @"Data Source = 198.1.8.16; Initial Catalog = JianDaMES; User ID = kendakv2; Password = kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static bool ExecuteNonQuery33(string query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=198.1.10.33;Failover Partner =198.1.10.31;Initial Catalog=erp;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = @"Data Source = 198.1.1.95; Initial Catalog = JianDaMES; User ID = kendakv2; Password = kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    int effectedRow = cmd.ExecuteNonQuery();
                    return effectedRow > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static DataTable ExecuteQuery34(string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=198.1.10.34;Initial Catalog=erp;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = @"Data Source = 198.1.8.16; Initial Catalog = JianDaMES; User ID = kendakv2; Password = kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static DataTable ExecuteQuery186(string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=198.1.9.186;Initial Catalog=BB;User ID=kendakv2;Password=kenda123";

            //string ConnectionString = "Data Source=198.1.8.1;Initial Catalog=BB;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = @"Data Source = 198.1.8.16; Initial Catalog = JianDaMES; User ID = kendakv2; Password = kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static bool ExecuteNonQuery186(string query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=198.1.9.186;Initial Catalog=BB;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = @"Data Source = 198.1.1.95; Initial Catalog = JianDaMES; User ID = kendakv2; Password = kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    int effectedRow = cmd.ExecuteNonQuery();
                    return effectedRow > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static DataTable ExecuteQuery21(string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=198.1.8.21;Initial Catalog=mfns;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = @"Data Source = 198.1.8.16; Initial Catalog = JianDaMES; User ID = kendakv2; Password = kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static DataTable ExecuteQuery22(string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=198.1.8.22;Initial Catalog=mfns;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = @"Data Source = 198.1.8.16; Initial Catalog = JianDaMES; User ID = kendakv2; Password = kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static DataTable ExecuteQuery23(string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=198.1.8.23;Initial Catalog=mfns;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = @"Data Source = 198.1.8.16; Initial Catalog = JianDaMES; User ID = kendakv2; Password = kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static DataTable ExecuteQuery24(string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=198.1.8.24;Initial Catalog=mfns;User ID=kendakv2;Password=kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static DataTable ExecuteQueryWithIP(string ip, string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=" + ip + ";Initial Catalog=mfns;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = "Data Source=198.1.9.186;Initial Catalog=BBFloor3;User ID=kendakv2;Password=kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static bool ExecuteNonQueryWithIP(string ip, string query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=" + ip + ";Initial Catalog=mfns;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = "Data Source=198.1.9.186;Initial Catalog=BBFloor3;User ID=kendakv2;Password=kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    int effectedRow = cmd.ExecuteNonQuery();
                    return effectedRow > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static DataTable ExecuteQueryWithIPmfnsshare(string ip, string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=" + ip + ";Initial Catalog=mfnsShareDB;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = "Data Source=198.1.9.186;Initial Catalog=BBFloor3;User ID=kendakv2;Password=kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static bool ExecuteNonQueryWithIPmfnsshare(string ip, string query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=" + ip + ";Initial Catalog=mfnsShareDB;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = "Data Source=198.1.9.186;Initial Catalog=BBFloor3;User ID=kendakv2;Password=kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    int effectedRow = cmd.ExecuteNonQuery();
                    return effectedRow > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static DataTable ExcuteQueryFloor3(string ip, string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=" + ip + ";Initial Catalog=mfns;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = "Data Source=198.1.9.186;Initial Catalog=BBFloor3;User ID=kendakv2;Password=kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public static DataTable ExcuteQueryFloor2(string ip, string Query, object[] parameter = null)
        {
            string ConnectionString = "Data Source=" + ip + ";Initial Catalog=CWSS_S7;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = "Data Source=198.1.9.186;Initial Catalog=BBFloor3;User ID=kendakv2;Password=kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }
    }
}