using System;
using System.Data;
using System.Threading.Tasks;
using BackToWorkFunctions.Model;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BackToWorkFunctions.Helper
{
    public class DbHelper
    {
        public static bool PostDataAsync<T>(T model, string ops)
        {
            try
            {
                var sqlConnectionString = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);

                switch (ops)
                {
                    case Constants.postUserInfo:
                        
                        using (var conn = new SqlConnection(sqlConnectionString))
                        {
                            string spName = @"dbo.[PostUserInfo]";
                            SqlCommand cmd = new SqlCommand(spName, conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = typeof(T).GetProperty("UserId").GetValue(model);
                            cmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = typeof(T).GetProperty("FullName").GetValue(model);
                            cmd.Parameters.Add("@YearOfBirth", SqlDbType.Int).Value = typeof(T).GetProperty("YearOfBirth").GetValue(model);
                            cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = typeof(T).GetProperty("EmailAddress").GetValue(model);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        
                    break;

                    case Constants.postLabTestInfo:
                        
                        using (var conn = new SqlConnection(sqlConnectionString))
                        {
                            string spName = @"dbo.[PostLabTestInfo]";
                            SqlCommand cmd = new SqlCommand(spName, conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = typeof(T).GetProperty("UserId").GetValue(model);
                            cmd.Parameters.Add("@DateOfEntry", SqlDbType.DateTime).Value = typeof(T).GetProperty("DateOfEntry").GetValue(model);
                            cmd.Parameters.Add("@TestType", SqlDbType.VarChar).Value = typeof(T).GetProperty("TestType").GetValue(model);
                            cmd.Parameters.Add("@TestDate", SqlDbType.DateTime).Value = typeof(T).GetProperty("TestDate").GetValue(model);
                            cmd.Parameters.Add("@TestResult", SqlDbType.VarChar).Value = typeof(T).GetProperty("TestResult").GetValue(model);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        
                    break;

                    case Constants.postRequestStatus:
                        
                        using (var conn = new SqlConnection(sqlConnectionString))
                        {
                            string spName = @"dbo.[PostRequestStatus]";
                            SqlCommand cmd = new SqlCommand(spName, conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = typeof(T).GetProperty("UserId").GetValue(model);
                            cmd.Parameters.Add("@DateOfEntry", SqlDbType.DateTime).Value = typeof(T).GetProperty("DateOfEntry").GetValue(model);
                            cmd.Parameters.Add("@ReturnRequestStatus", SqlDbType.VarChar).Value = typeof(T).GetProperty("UserId").GetValue(model);


                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        
                    break;

                    case Constants.postSymptomsInfo:
                        
                        using (var conn = new SqlConnection(sqlConnectionString))
                        {
                            string spName = @"dbo.[PostSymptomsInfo]";
                            SqlCommand cmd = new SqlCommand(spName, conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = typeof(T).GetProperty("UserId").GetValue(model);
                            cmd.Parameters.Add("@DateOfEntry", SqlDbType.DateTime).Value = typeof(T).GetProperty("DateOfEntry").GetValue(model);
                            cmd.Parameters.Add("@UserIsExposed", SqlDbType.Bit).Value = typeof(T).GetProperty("UserIsExposed").GetValue(model);
                            cmd.Parameters.Add("@ExposureDate", SqlDbType.DateTime).Value = typeof(T).GetProperty("ExposureDate").GetValue(model);
                            cmd.Parameters.Add("@QuarantineStartDate", SqlDbType.DateTime).Value = typeof(T).GetProperty("QuarantineStartDate").GetValue(model);
                            cmd.Parameters.Add("@QuarantineEndDate", SqlDbType.DateTime).Value = typeof(T).GetProperty("QuarantineEndDate").GetValue(model);
                            cmd.Parameters.Add("@IsSymptomatic", SqlDbType.Bit).Value = typeof(T).GetProperty("IsSymptomatic").GetValue(model);
                            cmd.Parameters.Add("@SymptomFever", SqlDbType.Bit).Value = typeof(T).GetProperty("SymptomFever").GetValue(model);
                            cmd.Parameters.Add("@SymptomCough", SqlDbType.Bit).Value = typeof(T).GetProperty("SymptomCough").GetValue(model);
                            cmd.Parameters.Add("@SymptomShortnessOfBreath", SqlDbType.Bit).Value = typeof(T).GetProperty("SymptomShortnessOfBreath").GetValue(model);
                            cmd.Parameters.Add("@SymptomChills", SqlDbType.Bit).Value = typeof(T).GetProperty("SymptomChills").GetValue(model);
                            cmd.Parameters.Add("@SymptomMusclePain", SqlDbType.Bit).Value = typeof(T).GetProperty("SymptomMusclePain").GetValue(model);
                            cmd.Parameters.Add("@SymptomSoreThroat", SqlDbType.Bit).Value = typeof(T).GetProperty("SymptomSoreThroat").GetValue(model);
                            cmd.Parameters.Add("@SymptomLossOfSmellTaste", SqlDbType.Bit).Value = typeof(T).GetProperty("SymptomLossOfSmellTaste").GetValue(model);
                            cmd.Parameters.Add("@SymptomVomiting", SqlDbType.Bit).Value = typeof(T).GetProperty("SymptomVomiting").GetValue(model);
                            cmd.Parameters.Add("@SymptomDiarrhea", SqlDbType.Bit).Value = typeof(T).GetProperty("SymptomDiarrhea").GetValue(model);
                            cmd.Parameters.Add("@Temperature", SqlDbType.Decimal).Value = typeof(T).GetProperty("Temperature").GetValue(model);
                            cmd.Parameters.Add("@UserIsSymptomatic", SqlDbType.Bit).Value = typeof(T).GetProperty("UserIsSymptomatic").GetValue(model);
                            cmd.Parameters.Add("@ClearToWorkToday", SqlDbType.Bit).Value = typeof(T).GetProperty("ClearToWorkToday").GetValue(model);
                            cmd.Parameters.Add("@GUID", SqlDbType.VarChar).Value = typeof(T).GetProperty("GUID").GetValue(model);


                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                       
                    break;
                }
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static async Task<T> GetDataAsync<T>(string ops, string paramString)
        {
            var sqlConStr = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);

            switch (ops)
            {
                case Constants.getUserInfo:                    
                    UserInfo userInfo = new UserInfo();
                    try
                    {
                        using (var conn = new SqlConnection(sqlConStr))
                        {
                            string spName = @"dbo.[GetUserInfo]";
                            SqlCommand cmd = new SqlCommand(spName, conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = paramString;

                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    userInfo.UserId = reader["UserId"].ToString();
                                    userInfo.FullName = reader["FullName"].ToString();
                                    userInfo.YearOfBirth = (int)reader["YearOfBirth"];
                                    userInfo.EmailAddress = reader["EmailAddress"].ToString();
                                }
                            }
                            reader.Close();
                            conn.Close();
                            return (T)Convert.ChangeType(userInfo, typeof(T));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }           

                case Constants.getLabTestInfo:
                    List<LabTestInfo> lstlabTestInfo = new List<LabTestInfo>();
                    try
                    {
                        using (var conn = new SqlConnection(sqlConStr))
                        {
                            string spName = @"dbo.[GetLabTestInfo]";
                            SqlCommand cmd = new SqlCommand(spName, conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = paramString;

                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    LabTestInfo labTestInfo = new LabTestInfo();
                                    labTestInfo.UserId = reader["UserId"].ToString();
                                    labTestInfo.DateOfEntry = reader["DateOfEntry"].ToString();
                                    labTestInfo.TestType = reader["TestType"].ToString();
                                    labTestInfo.TestDate = reader["TestDate"].ToString();
                                    labTestInfo.TestResult = reader["TestResult"].ToString();
                                    lstlabTestInfo.Add(labTestInfo);
                                }
                            }
                            reader.Close();
                            conn.Close();
                            return (T)Convert.ChangeType(lstlabTestInfo, typeof(T));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }

                case Constants.getRequestStatus:
                    List<RequestStatus> lstrequestStatus = new List<RequestStatus>();
                    try
                    {
                        using (var conn = new SqlConnection(sqlConStr))
                        {
                            string spName = @"dbo.[GetRequestStatus]";
                            SqlCommand cmd = new SqlCommand(spName, conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = paramString;

                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    RequestStatus requestStatus = new RequestStatus();
                                    requestStatus.UserId = reader["UserId"].ToString();
                                    requestStatus.DateOfEntry = reader["DateOfEntry"].ToString();
                                    requestStatus.ReturnRequestStatus = reader["ReturnRequestStatus"].ToString();
                                    lstrequestStatus.Add(requestStatus);
                                }
                            }
                            reader.Close();
                            conn.Close();
                            return (T)Convert.ChangeType(lstrequestStatus, typeof(T));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }

                default:
                    List<SymptomsInfo> lstsymptomsInfo = new List<SymptomsInfo>();

                    try
                    {
                        using (var conn = new SqlConnection(sqlConStr))
                        {
                            string spName = @"dbo.[GetSymptomsInfo]";
                            SqlCommand cmd = new SqlCommand(spName, conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = paramString;

                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    SymptomsInfo symptomsInfo = new SymptomsInfo();
                                    symptomsInfo.UserId = reader["UserId"].ToString();
                                    symptomsInfo.DateOfEntry = reader["DateOfEntry"].ToString();
                                    symptomsInfo.UserIsExposed = DBNull.Value.Equals(reader["UserIsExposed"]) ? false : (bool)reader["UserIsExposed"];
                                    symptomsInfo.ExposureDate = reader["ExposureDate"].ToString();
                                    symptomsInfo.QuarantineStartDate = reader["QuarantineStartDate"].ToString();
                                    symptomsInfo.QuarantineEndDate = reader["QuarantineEndDate"].ToString();
                                    symptomsInfo.IsSymptomatic = DBNull.Value.Equals(reader["IsSymptomatic"]) ? false : (bool)reader["IsSymptomatic"];
                                    symptomsInfo.SymptomFever = DBNull.Value.Equals(reader["SymptomFever"]) ? false : (bool)reader["SymptomFever"];
                                    symptomsInfo.SymptomCough = DBNull.Value.Equals(reader["SymptomCough"]) ? false : (bool)reader["SymptomCough"];
                                    symptomsInfo.SymptomShortnessOfBreath = DBNull.Value.Equals(reader["SymptomShortnessOfBreath"]) ? false : (bool)reader["SymptomShortnessOfBreath"];
                                    symptomsInfo.SymptomChills = DBNull.Value.Equals(reader["SymptomChills"]) ? false : (bool)reader["SymptomChills"];
                                    symptomsInfo.SymptomMusclePain = DBNull.Value.Equals(reader["SymptomMusclePain"]) ? false : (bool)reader["SymptomMusclePain"];
                                    symptomsInfo.SymptomSoreThroat = DBNull.Value.Equals(reader["SymptomSoreThroat"]) ? false : (bool)reader["SymptomSoreThroat"];
                                    symptomsInfo.SymptomLossOfSmellTaste = DBNull.Value.Equals(reader["SymptomLossOfSmellTaste"]) ? false : (bool)reader["SymptomLossOfSmellTaste"];
                                    symptomsInfo.SymptomVomiting = DBNull.Value.Equals(reader["SymptomVomiting"]) ? false : (bool)reader["SymptomVomiting"];
                                    symptomsInfo.SymptomDiarrhea = DBNull.Value.Equals(reader["SymptomDiarrhea"]) ? false : (bool)reader["SymptomDiarrhea"];
                                    symptomsInfo.Temperature = DBNull.Value.Equals(reader["Temperature"]) ? 0 : (decimal)reader["Temperature"];
                                    symptomsInfo.UserIsSymptomatic = DBNull.Value.Equals(reader["UserIsSymptomatic"]) ? false : (bool)reader["UserIsSymptomatic"];
                                    symptomsInfo.ClearToWorkToday = DBNull.Value.Equals(reader["ClearToWorkToday"]) ? false : (bool)reader["ClearToWorkToday"];
                                    symptomsInfo.GUID = reader["GUID"].ToString();
                                    lstsymptomsInfo.Add(symptomsInfo);
                                }
                            }
                            reader.Close();
                            conn.Close();
                            return (T)Convert.ChangeType(lstsymptomsInfo, typeof(T));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
            }
        }

        public static bool GetTeamsAddress(List<TeamsAddressQuarantineInfo> teamsAddressQuarantineInfoCollector)
        {
            var sqlConStr = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetAllTeamsAddress", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            TeamsAddressQuarantineInfo teamsAddressQuarantineInfo = new TeamsAddressQuarantineInfo();
                            teamsAddressQuarantineInfo.UserId = reader["UserId"].ToString();
                            teamsAddressQuarantineInfo.TeamsAddress = reader["TeamsAddress"].ToString();
                            teamsAddressQuarantineInfoCollector.Add(teamsAddressQuarantineInfo);
                        }
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static bool GetUserContactInfo(List<UserContactInfo> userContactInfoCollector)
        {
            var sqlConStr = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetAllUsersContactInfo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            UserContactInfo userContactInfo = new UserContactInfo();
                            userContactInfo.UserId = reader["UserId"].ToString();
                            userContactInfo.FullName = reader["FullName"].ToString();
                            userContactInfo.EmailAddress = reader["EmailAddress"].ToString();
                            userContactInfo.MobilePhone = reader["MobileNumber"].ToString();
                            userContactInfoCollector.Add(userContactInfo);
                        }
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
