using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BM_TimeTracker.Classes
{
    class TimeTrackerDataProvider
    {
        static TimeTrackerDataProvider _provider = null;
        string connectionString;

        private TimeTrackerDataProvider()
        {
            this.connectionString = Util.GetConnectionString();
        }
        public static TimeTrackerDataProvider Instance()
        {
            if (_provider == null)
                _provider = new TimeTrackerDataProvider();

            return _provider;
        }

        #region SELECT
        public DataTable GetUserByUserName(string name)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand getUserByUsername = new SqlCommand("[TT_GetUser_ByUsername]", con) { CommandType = CommandType.StoredProcedure };
                getUserByUsername.Parameters.AddWithValue("@username", name);
                SqlDataAdapter da = new SqlDataAdapter(getUserByUsername);
                DataTable userTable = new DataTable();
                da.Fill(userTable);
                return userTable;
            }
        }
        public int GetUserAnzahl()
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand getUserAnzahl = new SqlCommand("TT_GetUserAnzahl", con) { CommandType = CommandType.StoredProcedure };
                SqlDataAdapter da = new SqlDataAdapter(getUserAnzahl);
                DataTable userAnzahlTable = new DataTable();
                da.Fill(userAnzahlTable);

                int userAnzahl = Convert.ToInt32(userAnzahlTable.Rows[0][0]);
                return userAnzahl;
            }
        }
        public DataTable GetUserGuidByID(int userID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand getUserGuidByUserID = new SqlCommand("[TT_GetUserGuid_byUserID]", con) { CommandType = CommandType.StoredProcedure };
                getUserGuidByUserID.Parameters.AddWithValue("@userID", userID);
                SqlDataAdapter da = new SqlDataAdapter(getUserGuidByUserID);
                DataTable userGuid = new DataTable();
                da.Fill(userGuid);
                return userGuid;
            }
        }
        public int GetMindestZeit()
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand getMindestZeit = new SqlCommand("[TT_GetEinstellungenMindestZeit]", con) { CommandType = CommandType.StoredProcedure };
                SqlDataAdapter da = new SqlDataAdapter(getMindestZeit);
                DataTable mindestTable = new DataTable();
                da.Fill(mindestTable);
                return Convert.ToInt32(mindestTable.Rows[0][0]);
            }
        }
        public DataTable GetEventsByAufgabe(int aufgabeID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand getEvents = new SqlCommand("TT_GetStartEnddatum_byAufgabeID", con) { CommandType = CommandType.StoredProcedure };
                getEvents.Parameters.AddWithValue("@aufgabeID", aufgabeID);
                SqlDataAdapter da = new SqlDataAdapter(getEvents);
                DataTable eventTable = new DataTable();
                da.Fill(eventTable);
                return eventTable;
            }
        }
        public DataTable GetAufgabeByID(int aufgabeID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand getAufgabeByID = new SqlCommand("TT_GetAufgabe_byID", con) { CommandType = CommandType.StoredProcedure };
                getAufgabeByID.Parameters.AddWithValue("@AufgabeID", aufgabeID);
                SqlDataAdapter da = new SqlDataAdapter(getAufgabeByID);
                DataTable aufgabeTable = new DataTable();
                da.Fill(aufgabeTable);
                return aufgabeTable;
            }
        }
        public DataTable GetAufgabeByStartdatumEnddatumUser(int userID, DateTime startdatum, DateTime enddatum)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand getaufgabeStartEnd = new SqlCommand("[TT_GetAugabe_ByUserIDStartEnddatum]", con) { CommandType = CommandType.StoredProcedure };
                getaufgabeStartEnd.Parameters.AddWithValue("@userID", userID);
                getaufgabeStartEnd.Parameters.AddWithValue("@startdatum", startdatum);
                getaufgabeStartEnd.Parameters.AddWithValue("@enddatum", enddatum);

                SqlDataAdapter da = new SqlDataAdapter(getaufgabeStartEnd);
                DataTable aufgaben = new DataTable();
                da.Fill(aufgaben);
                return aufgaben;
            }
        }
        public DataTable GetAufgabeByStartdatumEnddatumUserAktiv(int userID, DateTime startdatum, DateTime enddatum)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand getaufgabeStartEndAktiv = new SqlCommand("[TT_GetAugabe_ByUserIDStartEnddatumAktiv]", con) { CommandType = CommandType.StoredProcedure };
                getaufgabeStartEndAktiv.Parameters.AddWithValue("@userID", userID);
                getaufgabeStartEndAktiv.Parameters.AddWithValue("@startdatum", startdatum);
                getaufgabeStartEndAktiv.Parameters.AddWithValue("@enddatum", enddatum);

                SqlDataAdapter da = new SqlDataAdapter(getaufgabeStartEndAktiv);
                DataTable aufgaben = new DataTable();
                da.Fill(aufgaben);
                return aufgaben;
            }
        }
        public int GetActiveAufgabeID(int userID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand getactive = new SqlCommand("[TT_GetAufgabeID_ByUserIDEnddatumNULL]", con) { CommandType = CommandType.StoredProcedure };
                getactive.Parameters.AddWithValue("@userID", userID);

                SqlDataAdapter da = new SqlDataAdapter(getactive);
                DataTable activeAufgabeID = new DataTable();
                da.Fill(activeAufgabeID);

                if (activeAufgabeID.Rows.Count == 0)
                    return 0;
                else
                    return Convert.ToInt32(activeAufgabeID.Rows[0][0]);
            }
        }
        public DataTable GetAllUsers()
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlselect_Users = new SqlCommand("[TT_GetUser_All]", con);
                sqlselect_Users.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter() { SelectCommand = sqlselect_Users };
                DataTable dtblUsers = new DataTable();
                da.Fill(dtblUsers);

                return dtblUsers;
            }
        }
        public DataTable GetUserByID(int userID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand userByUserID = new SqlCommand("[TT_GetUser_ByUserID]", con);
                userByUserID.CommandType = CommandType.StoredProcedure;
                userByUserID.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter da = new SqlDataAdapter(userByUserID);
                DataTable dtblUsers = new DataTable();
                da.Fill(dtblUsers);

                return dtblUsers;
            }
        }
        public DataTable GetAllUsersLoggedWithDate()
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand getUsersLogged = new SqlCommand("[TT_GetKritisch_All]", con) { CommandType = CommandType.StoredProcedure };
                SqlDataAdapter da = new SqlDataAdapter(getUsersLogged);
                DataTable usersLogged = new DataTable();
                da.Fill(usersLogged);
                return usersLogged;
            }
        }
        public DataTable GetLoggedWithDateByUserID(int userId)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand userLogged = new SqlCommand("TT_GetKritisch_byUserID", con) { CommandType = CommandType.StoredProcedure };
                userLogged.Parameters.AddWithValue("@userID", userId);
                SqlDataAdapter da = new SqlDataAdapter(userLogged);
                DataTable userData = new DataTable();
                da.Fill(userData);
                return userData;
            }
        }
        public DataTable GetLastAufgabe(int userID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand getlast = new SqlCommand("TT_GetAufgabe_last", con) { CommandType = CommandType.StoredProcedure };
                getlast.Parameters.AddWithValue("@userid", userID);
                SqlDataAdapter da = new SqlDataAdapter(getlast);
                DataTable lastTable = new DataTable();
                da.Fill(lastTable);

                if (lastTable.Rows.Count > 0)
                    return lastTable;
                else
                    return null;
            }
        }




        #endregion

        #region UPDATE
        public void UpdateUserPassword(int userID, string passwordHash)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand updateUserPassword = new SqlCommand("TT_SetUserPassword_byID", con) { CommandType = CommandType.StoredProcedure };
                updateUserPassword.Parameters.AddWithValue("@userID", userID);
                updateUserPassword.Parameters.AddWithValue("@password", passwordHash);
                con.Open();
                updateUserPassword.ExecuteNonQuery();
            }
        }
        public void UpdateUserPasswordAdmin(int userID, string passwordHash, bool admin)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand updateUserPasswordAdmin = new SqlCommand("TT_SetUserPasswordAdmin_byID", con) { CommandType = CommandType.StoredProcedure };
                updateUserPasswordAdmin.Parameters.AddWithValue("@password", passwordHash);
                updateUserPasswordAdmin.Parameters.AddWithValue("@useriD", userID);
                updateUserPasswordAdmin.Parameters.AddWithValue("@admin", admin);
                con.Open();
                updateUserPasswordAdmin.ExecuteNonQuery();
            }
        }

        public void UpdateEventWhereEnddatumNULLByAufgabeID(int aufgabeID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlupdateEvent = new SqlCommand("[TT_SetEventEnddatum_ByAufgabeID]", con);
                sqlupdateEvent.CommandType = CommandType.StoredProcedure;
                sqlupdateEvent.Parameters.AddWithValue("@Enddatum", DateTime.Now);
                sqlupdateEvent.Parameters.AddWithValue("@AufgabeID", aufgabeID);

                con.Open();
                sqlupdateEvent.ExecuteNonQuery();
            }
        }
        public void UpdateAufgabe(int aufgabeID, string name, bool intern, int zeit, DateTime datum, bool abschluss)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand updateAufgabe = new SqlCommand("[TT_SetAufgabe_byID]", con);
                updateAufgabe.CommandType = CommandType.StoredProcedure;
                updateAufgabe.Parameters.AddWithValue("@AufgabeName", name);
                updateAufgabe.Parameters.AddWithValue("@Intern", intern);
                updateAufgabe.Parameters.AddWithValue("@Zeit", zeit);
                updateAufgabe.Parameters.AddWithValue("@AufgabeID", aufgabeID);
                updateAufgabe.Parameters.AddWithValue("@Datum", datum);
                updateAufgabe.Parameters.AddWithValue("@Abschluss", abschluss);
                con.Open();
                updateAufgabe.ExecuteNonQuery();
            }
        }
        public void UpdateAufgabeZeitNULL(int aufgabeID, string name, bool intern, DateTime datum, bool abschluss)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand updateAufgabe = new SqlCommand("[TT_SetAufgabe_byID]", con);
                updateAufgabe.CommandType = CommandType.StoredProcedure;
                updateAufgabe.Parameters.AddWithValue("@AufgabeName", name);
                updateAufgabe.Parameters.AddWithValue("@Intern", intern);
                updateAufgabe.Parameters.AddWithValue("@Zeit", DBNull.Value);
                updateAufgabe.Parameters.AddWithValue("@AufgabeID", aufgabeID);
                updateAufgabe.Parameters.AddWithValue("@Datum", datum);
                updateAufgabe.Parameters.AddWithValue("@Abschluss", abschluss);
                con.Open();
                updateAufgabe.ExecuteNonQuery();
            }
        }


        public void UpdateAufgabeGeloescht(int aufgabeID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand updateAufgabeDel = new SqlCommand("[TT_SetAufgabeGeloescht_ByAufgabeID]", con) { CommandType = CommandType.StoredProcedure };
                updateAufgabeDel.Parameters.AddWithValue("@aufgabeID", aufgabeID);
                con.Open();
                updateAufgabeDel.ExecuteNonQuery();
            }
        }



        #endregion

        #region INSERT
        public DataTable InsertUserGetID(string username, string passwordHash, string guid, bool admin)
        {

            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand insertUserGetID = new SqlCommand("TT_InsertBenutzerGetID", con) { CommandType = CommandType.StoredProcedure };
                insertUserGetID.Parameters.AddWithValue("@username", username);
                insertUserGetID.Parameters.AddWithValue("@password", passwordHash);
                insertUserGetID.Parameters.AddWithValue("@guid", guid);
                SqlDataAdapter da = new SqlDataAdapter(insertUserGetID);
                DataTable userTable = new DataTable();
                da.Fill(userTable);

                SqlCommand setUserAdmin = new SqlCommand("UPDATE Benutzer Set admin = @admin WHERE UserID = @userID", con);
                int userID = Convert.ToInt32(userTable.Rows[0][0]);
                setUserAdmin.Parameters.AddWithValue("@userID", userID);
                setUserAdmin.Parameters.AddWithValue("@admin", admin);


                con.Open();
                setUserAdmin.ExecuteNonQuery();

                return userTable;
            }
        }
        public void StopCurrentRunnigEvent(int userID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand stopRunning = new SqlCommand("TT_SetEvent_byUserIDEnddatumNULL", con) { CommandType = CommandType.StoredProcedure };
                stopRunning.Parameters.AddWithValue("@UserID", userID);
                stopRunning.Parameters.AddWithValue("@Enddatum", DateTime.Now);
                con.Open();
                stopRunning.ExecuteNonQuery();
            }
        }
        public DataTable InsertAufgabeGetData(int userID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand insertAufgabe = new SqlCommand("[TT_InsertAufgabeGetID]", con);
                insertAufgabe.CommandType = CommandType.StoredProcedure;
                insertAufgabe.Parameters.AddWithValue("@UserID", userID);
                insertAufgabe.Parameters.AddWithValue("@AufgabeName", Ressources.strings.manage_inediting);
                insertAufgabe.Parameters.AddWithValue("@Intern", true);

                SqlDataAdapter da = new SqlDataAdapter(insertAufgabe);
                DataTable aufgabeIDTable = new DataTable();
                da.Fill(aufgabeIDTable);

                int aufgabeID = Convert.ToInt32(aufgabeIDTable.Rows[0][0]);
                return TimeTrackerDataProvider.Instance().GetAufgabeByID(aufgabeID);
            }
        }
        public void InsertEvent(int aufgabeID, DateTime start, DateTime end)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand insertEvent = new SqlCommand("[TT_InsertEvent]", con) { CommandType = CommandType.StoredProcedure };
                insertEvent.Parameters.AddWithValue("@aufgabeID", aufgabeID);
                insertEvent.Parameters.AddWithValue("@startdatum", start);
                insertEvent.Parameters.AddWithValue("@enddatum", end);

                con.Open();
                insertEvent.ExecuteNonQuery();
            }
        }
        public void InsertEventEnddatumNULL(int aufgabeID, DateTime start)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand insertStartEvent = new SqlCommand("[TT_InsertEvent]", con) { CommandType = CommandType.StoredProcedure };
                insertStartEvent.Parameters.AddWithValue("@aufgabeID", aufgabeID);
                insertStartEvent.Parameters.AddWithValue("@startdatum", start);
                insertStartEvent.Parameters.AddWithValue("@enddatum", DBNull.Value);

                con.Open();
                insertStartEvent.ExecuteNonQuery();
            }
        }

        #endregion


        #region SET
        public void SetMindestZeit(int mindestZeit)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand setMindestZeit = new SqlCommand("[TT_SetEinstellungenMindestZeit]", con) { CommandType = CommandType.StoredProcedure };
                setMindestZeit.Parameters.AddWithValue("@Zeit", mindestZeit);

                con.Open();
                setMindestZeit.ExecuteNonQuery();
            }
        }
        #endregion

        #region DELETE
        public void DeleteUserByUserID(int userID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand deleteEvents = new SqlCommand("[TT_DeleteEvents_byUserID]", con);
                deleteEvents.CommandType = CommandType.StoredProcedure;
                deleteEvents.Parameters.AddWithValue("@UserID", userID);

                SqlCommand deleteAufgaben = new SqlCommand("[TT_DeleteAufgaben_byUserID]", con);
                deleteAufgaben.CommandType = CommandType.StoredProcedure;
                deleteAufgaben.Parameters.AddWithValue("@UserID", userID);

                SqlCommand deleteUser = new SqlCommand("[TT_DeleteBenutzer_ByID]", con);
                deleteUser.CommandType = CommandType.StoredProcedure;
                deleteUser.Parameters.AddWithValue("@UserID", userID);

                con.Open();
                SqlTransaction trans = con.BeginTransaction();
                try
                {
                    deleteEvents.Transaction = trans;
                    deleteAufgaben.Transaction = trans;
                    deleteUser.Transaction = trans;

                    deleteEvents.ExecuteNonQuery();
                    deleteAufgaben.ExecuteNonQuery();
                    deleteUser.ExecuteNonQuery();

                    trans.Commit();

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }


        #endregion

    }
}
