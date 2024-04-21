using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using System.Data;
using System.Data.SqlClient;
using CodeBuddies.Resources.Data;
using System;
using CodeBuddies.Models.Exceptions;
using static CodeBuddies.Resources.Data.Constants;

namespace CodeBuddies.Repositories
{
    internal class SessionRepository : DBRepositoryBase
    {
        public SessionRepository() : base() { }


        public List<Message> GetMessagesForSpecificSession(long sessionId)
        {
            List<Message> sessionMessages = new List<Message>();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            DataSet messagesDataSet = new DataSet();
            string selectAllMessagesForSpecificSession = "SELECT * FROM Messages m inner join MessagesSessions ms on m.id = ms.message_id where ms.session_id = @id ";
            SqlCommand selectAllMessagesForSpecificSessionCommand = new SqlCommand(selectAllMessagesForSpecificSession, sqlConnection);
            selectAllMessagesForSpecificSessionCommand.Parameters.AddWithValue("@id", sessionId);
            dataAdapter.SelectCommand = selectAllMessagesForSpecificSessionCommand;
            dataAdapter.Fill(messagesDataSet, "Messages");

            foreach (DataRow messageRow in messagesDataSet.Tables["Messages"].Rows)
            {
                Message currentMessage = new Message((long)messageRow["id"], Convert.ToDateTime(messageRow["message_timestamp"]), messageRow["content"].ToString(), (long)messageRow["sender_id"]);
                sessionMessages.Add(currentMessage);
            }

            return sessionMessages;
        }

        public List<CodeContribution> GetCodeContributionsForSpecificSession(long sessionId)
        {
            List<CodeContribution> codeContributions = new List<CodeContribution>();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet codeContributionsDataSet = new DataSet();
            string selectAllCodeContributionsForSpecificSession = "SELECT * FROM CodeContributions where session_id = @id";
            SqlCommand selectAllCodeContributionsForSpecificSessionCommand = new SqlCommand(selectAllCodeContributionsForSpecificSession, sqlConnection);
            selectAllCodeContributionsForSpecificSessionCommand.Parameters.AddWithValue("@id", sessionId);
            dataAdapter.SelectCommand = selectAllCodeContributionsForSpecificSessionCommand;
            dataAdapter.Fill(codeContributionsDataSet, "CodeContributions");

            foreach (DataRow codeContributionRow in codeContributionsDataSet.Tables["CodeContributions"].Rows)
            {
                CodeContribution currentCodeContribution = new CodeContribution((long)codeContributionRow["buddy_id"], Convert.ToDateTime(codeContributionRow["contribution_date"]), (int)codeContributionRow["contribution_value"]);
                codeContributions.Add(currentCodeContribution);
            }

            return codeContributions;
        }

        public List<Message> GetMessagesForSpecificCodeReview(long codeReviewId)
        {
            List<Message> codeReviewMessages = new List<Message>();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet messagesDataSet = new DataSet();
            string selectAllMessagesForSpecificCodeReview = "SELECT * FROM Messages m inner join MessagesCodeReviews mcr on m.id = mcr.message_id where mcr.code_review_id = @id ";
            SqlCommand selectAllMessagesForSpecificCodeReviewCommand = new SqlCommand(selectAllMessagesForSpecificCodeReview, sqlConnection);
            selectAllMessagesForSpecificCodeReviewCommand.Parameters.AddWithValue("@id", codeReviewId);
            dataAdapter.SelectCommand = selectAllMessagesForSpecificCodeReviewCommand;
            dataAdapter.Fill(messagesDataSet, "Messages");

            foreach (DataRow messageRow in messagesDataSet.Tables["Messages"].Rows)
            {
                Message currentMessage = new Message((long)messageRow["id"], Convert.ToDateTime(messageRow["message_timestamp"]), messageRow["content"].ToString(), (long)messageRow["sender_id"]);
                codeReviewMessages.Add(currentMessage);
            }

            return codeReviewMessages;
        }



        public List<CodeReviewSection> GetCodeReviewSectionsForSpecificSession(long sessionId)
        {
            List<CodeReviewSection> codeReviewSections = new List<CodeReviewSection>();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet codeReviewSectionsDataSet = new DataSet();
            string selectAllCodeReviewSectionsForSpecificSession = "SELECT * FROM CodeReviews cr inner join CodeReviewsSessions crs on cr.id = crs.code_review_id where crs.session_id = @id ";
            SqlCommand selectAllCodeReviewSectionsForSpecificSessionCommand = new SqlCommand(selectAllCodeReviewSectionsForSpecificSession, sqlConnection);
            selectAllCodeReviewSectionsForSpecificSessionCommand.Parameters.AddWithValue("@id", sessionId);
            dataAdapter.SelectCommand = selectAllCodeReviewSectionsForSpecificSessionCommand;
            dataAdapter.Fill(codeReviewSectionsDataSet, "CodeReviews");

            foreach (DataRow codeReviewSectionRow in codeReviewSectionsDataSet.Tables["CodeReviews"].Rows)
            {
                bool isClosed = false;
                if (codeReviewSectionRow["code_review_status"].ToString() != "closed")
                    isClosed = true;


                CodeReviewSection currentCodeReviewSection = new CodeReviewSection((long)codeReviewSectionRow["id"], (long)codeReviewSectionRow["owner_id"], GetMessagesForSpecificCodeReview((long)codeReviewSectionRow["id"]), codeReviewSectionRow["code_section"].ToString(), isClosed);
                codeReviewSections.Add(currentCodeReviewSection);
            }

            return codeReviewSections;
        }

        public List<long> GetBuddiesForSpecificSession(long sessionId)
        {
            List<long> sessionBuddies = new List<long>();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet buddiesDataSet = new DataSet();
            string selectAllBuddiesForSpecificSession = "SELECT * FROM BuddiesSessions where session_id = @id";
            SqlCommand selectAllBuddiesForSpecificSessionCommand = new SqlCommand(selectAllBuddiesForSpecificSession, sqlConnection);
            selectAllBuddiesForSpecificSessionCommand.Parameters.AddWithValue("@id", sessionId);
            dataAdapter.SelectCommand = selectAllBuddiesForSpecificSessionCommand;
            dataAdapter.Fill(buddiesDataSet, "BuddiesSessions");

            foreach (DataRow currentRow in buddiesDataSet.Tables["BuddiesSessions"].Rows)
            {
                sessionBuddies.Add((long)currentRow["buddy_id"]);
            }

            return sessionBuddies;
        }

        public List<Session> GetAllSessionsOfABuddy(long buddyId)
        {
            List<Session> sessions = new List<Session>();

            DataSet sessionDataSet = new DataSet();
            string selectAllSessions = "SELECT * FROM Sessions s INNER JOIN BuddiesSessions bs ON s.id = bs.session_id WHERE bs.buddy_id=@user_id";
            SqlCommand selectAllSessionsCommand = new SqlCommand(selectAllSessions, sqlConnection);
            selectAllSessionsCommand.Parameters.AddWithValue("@user_id", buddyId);
            dataAdapter.SelectCommand = selectAllSessionsCommand;
            dataAdapter.Fill(sessionDataSet, "Sessions");

            foreach (DataRow sessionRow in sessionDataSet.Tables["Sessions"].Rows)
            {
                List<Message> sessionMessages = GetMessagesForSpecificSession((long)sessionRow["id"]);
                List<long> sessionBuddies = GetBuddiesForSpecificSession((long)sessionRow["id"]);
                List<CodeContribution> sessionCodeContributions = GetCodeContributionsForSpecificSession((long)sessionRow["id"]);
                List<CodeReviewSection> sessionCodeReviewSections = GetCodeReviewSectionsForSpecificSession((long)sessionRow["id"]);


                Session session = new Session((long)sessionRow["id"], (long)sessionRow["owner_id"], sessionRow["session_name"].ToString(), Convert.ToDateTime(sessionRow["creation_date"]), Convert.ToDateTime(sessionRow["last_edit_date"]), sessionBuddies, sessionMessages, sessionCodeContributions, sessionCodeReviewSections, new List<string>(), new TextEditor("black", new List<string>()), new DrawingBoard(""));
                sessions.Add(session);

            }

            return sessions;
        }

        public void AddBuddyMemberToSession(long buddyId, long sessionId)
        {
            string insertQuery = "INSERT INTO BuddiesSessions (buddy_id, session_id) VALUES (@BuddyId, @SessionId)";
            try
            {

                using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
                {
                    insertCommand.Parameters.AddWithValue("@BuddyId", buddyId);
                    insertCommand.Parameters.AddWithValue("@SessionId", sessionId);

                    insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new EntityAlreadyExists(ex.Message); }
        }

        public string GetSessionName(long sessionId)
        {
            string sessionName = null;

            string selectSessionNameQuery = "SELECT session_name FROM Sessions WHERE id = @SessionId";

            try
            {
                using (SqlCommand selectCommand = new SqlCommand(selectSessionNameQuery, sqlConnection))
                {
                    selectCommand.Parameters.AddWithValue("@SessionId", sessionId);

                    object result = selectCommand.ExecuteScalar();

                    // Check if the result is not null
                    if (result != null)
                    {
                        sessionName = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NullColumn(ex.Message);
            }

            return sessionName;
        }

        public long GetFreeSessionId()
        {
            long freeSessionId = 0;

            // Execute a query to find a free session id
            string query = "SELECT TOP 1 id FROM Sessions ORDER BY id DESC";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                object result = command.ExecuteScalar();
                if (result != null && long.TryParse(result.ToString(), out long lastSessionId))
                {
                    freeSessionId = lastSessionId + 1;
                }
                else
                {
                    // Handle if no sessions exist in the database
                    freeSessionId = 1;
                }
            }

            return freeSessionId;
        }

        public long AddNewSession(string sessionName, long ownerId, int maxParticipants)
        {
            long sessionId = 0;

            // Get a free session id
            long freeSessionId = GetFreeSessionId();

            string insertQuery = "INSERT INTO Sessions (id, owner_id, session_name, creation_date, last_edit_date) VALUES (@SessionId, @OwnerId, @SessionName, @CreationDate, @LastEditDate)";
            string insertMemberQuery = "INSERT INTO BuddiesSessions (buddy_id, session_id) VALUES (@BuddyId, @SessionId)";

            try
            {
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
                {
                    insertCommand.Parameters.AddWithValue("@SessionId", freeSessionId);
                    insertCommand.Parameters.AddWithValue("@SessionName", sessionName);
                    insertCommand.Parameters.AddWithValue("@OwnerId", ownerId);
                    insertCommand.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@LastEditDate", DateTime.Now);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        sessionId = freeSessionId;
                    }
                }

                using (SqlCommand insertCommand = new SqlCommand(insertMemberQuery, sqlConnection))
                {

                    insertCommand.Parameters.AddWithValue("@BuddyId", ownerId);
                    insertCommand.Parameters.AddWithValue("@SessionId", freeSessionId);

                    insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new EntityAlreadyExists(ex.Message);
            }
            return sessionId;
        }

    }
}
