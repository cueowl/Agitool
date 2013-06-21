
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Configuration.Provider;
//using System.Data;
//using System.Data.Sql;
//using System.Diagnostics;
//using System.Globalization;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Web;
//using System.Web.Helpers;
//using System.Web.Security;
//using WebMatrix.Data;
//using WebMatrix.WebData;
//using WebMatrix.WebData.Resources;

//namespace AgiSoft.MemProv {
//    public class Cue_MembProv : ExtendedMembershipProvider {

//        // Fields
//        private const int TokenSizeInBytes = 16;
//        private readonly MembershipProvider _previousProvider;
//        private string MembershipTableName = "Membership";
//        private string OAuthMembershipTableName = "OAuthMembership";
        

//        // Constructor
//        public Cue_MembProv() : this(null) {
//        }

//        public Cue_MembProv(MembershipProvider previousProvider) {
//            _previousProvider = previousProvider;
//            if(_previousProvider != null){
//                _previousProvider.ValidatingPassword += (sender, args) => {
//                    if (!InitializeCalled) {
//                        OnValidatingPassword(args);
//                    }
//                };
//            }
//        }

//        public override void Initialize(string name, NameValueCollection config) {
//            if (config == null) {
//                throw new ArgumentNullException("config");
//            }
//            if (String.IsNullOrEmpty(name)) {
//                name = "Cue-MembProv";
//            }
//            if (String.IsNullOrEmpty(config["description"])) {
//                config.Remove("description");
//                config.Add("description", "CueOwl Membership Provider");
//            }
//            base.Initialize(name, config);

//            config.Remove("connectionStringName");
//            config.Remove("enablePasswordRetrieval");
//            config.Remove("enablePasswordReset");
//            config.Remove("requiresQuestionAndAnswer");
//            config.Remove("applicationName");
//            config.Remove("requiresUniqueEmail");
//            config.Remove("maxInvalidPasswordAttempts");
//            config.Remove("passwordAttemptWindow");
//            config.Remove("passwordFormat");
//            config.Remove("name");
//            config.Remove("description");
//            config.Remove("minRequiredPasswordLength");
//            config.Remove("minRequiredNonalphanumericCharacters");
//            config.Remove("passwordStrengthRegularExpression");
//            config.Remove("hashAlgorithmType");

//            if (config.Count > 0) {
//                string attribUnrecognized = config.GetKey(0);
//                if (!String.IsNullOrEmpty(attribUnrecognized)) {
//                    throw new ProviderException();
//                }
//            }
//        }

//        #region Private Properties

//        // Properties (PRIVATE)
//        private MembershipProvider PreviousProvider {
//            get {
//                if (_previousProvider == null) {
//                    throw new InvalidOperationException();
//                }
//                else {
//                    return _previousProvider;
//                }
//            }
//        }

//        private string SafeUserTableName {
//            get { return "[" + UserTableName + "]"; }
//        }

//        private string SafeUserIdColumn {
//            get { return "[" + UserIdColumn + "]"; }
//        }

//        private string SafeUserNameColumn {
//            get { return "[" + UserNameColumn + "]"; }
//        }
//        #endregion

//        #region Public Properties

//        // Properties (PUBLIC)
//        internal bool InitializeCalled { get; set; }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override string ApplicationName {
//            get {
//                if (InitializeCalled) {
//                    throw new NotSupportedException();
//                }
//                else {
//                    return PreviousProvider.ApplicationName;
//                }
//            }
//            set {
//                if (InitializeCalled) {
//                    throw new NotSupportedException();
//                }
//                else {
//                    PreviousProvider.ApplicationName = value;
//                }
//            }
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override bool EnablePasswordRetrieval {
//            get { return InitializeCalled ? false : PreviousProvider.EnablePasswordRetrieval; }
//        }
        
//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override bool EnablePasswordReset {
//            get { return InitializeCalled ? false : PreviousProvider.EnablePasswordReset; }
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override int MaxInvalidPasswordAttempts {
//            get { return InitializeCalled ? Int32.MaxValue : PreviousProvider.MaxInvalidPasswordAttempts; }
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override int MinRequiredNonAlphanumericCharacters {
//            get { return InitializeCalled ? 0 : PreviousProvider.MinRequiredNonAlphanumericCharacters; }
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override int MinRequiredPasswordLength {
//            get { return InitializeCalled ? 0 : PreviousProvider.MinRequiredPasswordLength; }
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override int PasswordAttemptWindow {
//            get { return InitializeCalled ? Int32.MaxValue : PreviousProvider.PasswordAttemptWindow; }
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override MembershipPasswordFormat PasswordFormat {
//            get { return InitializeCalled ? MembershipPasswordFormat.Hashed : PreviousProvider.PasswordFormat; }
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override string PasswordStrengthRegularExpression {
//            get { return InitializeCalled ? string.Empty : PreviousProvider.PasswordStrengthRegularExpression; }
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override bool RequiresQuestionAndAnswer {
//            get { return InitializeCalled ? false : PreviousProvider.RequiresQuestionAndAnswer; }
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override bool RequiresUniqueEmail {
//            get { return InitializeCalled ? false : PreviousProvider.RequiresUniqueEmail; }
//        }

//        // represents the User table for the app
//        public string UserTableName { get; set; }

//        // represents the User created UserName column, i.e. Email
//        public string UserNameColumn { get; set; }

//        // Represents the User created id column, i.e. ID;
//        // REVIEW: we could get this from the primary key of UserTable in the future
//        public string UserIdColumn { get; set; }

//        #endregion

//        #region Commands
//        // Commands
       
//        public override bool ChangePassword(string username, string oldPassword, string newPassword) {
//            if (!InitializeCalled) {
//                return PreviousProvider.ChangePassword(username, oldPassword, newPassword);
//            }

//            if (string.IsNullOrEmpty(username)) {
//                throw new ArgumentException();
//            }

//            if (string.IsNullOrEmpty(oldPassword)) {
//                throw new ArgumentException();
//            }

//            if (string.IsNullOrEmpty(newPassword)) {
//                throw new ArgumentException();
//            }

//            using (var db = ConnectToDatabase()) {
//                int userId = GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, username);
//                if(userId == -1){
//                    return false;
//                }
                
//                if(!CheckPassword(db, userId, oldPassword)){
//                    return false;
//                }

//                return SetPassword(db, userId, newPassword);
//            }
//        }

//        internal virtual IDatabase ConnectToDatabase() {
//            return new DatabaseWrapper(ConnectionInfo.Connect());
//        }

//        private bool SetPassword(Database db, int userId, string newPassword) {
//            string hashedPassword = Crypto.HashPassword(newPassword);
//            if (hashedPassword.Length > 128) {
//                throw new ArgumentException();
//            }

//            // Update new password
//            int result = db.Execute(@"UPDATE Membership SET Password=@0, PasswordSalt=@1, PasswordChangedDate=@2 WHERE UserId = @3", hashedPassword, String.Empty /* salt column is unused */, DateTime.UtcNow, userId);
//            return result > 0;
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer) {
//            if (!InitializeCalled) {
//                return PreviousProvider.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
//            }
//            throw new NotSupportedException();
//        }

//        public override string CreateAccount(string userName, string password, bool requireConfirmationToken) {
//            VerifyInitialized();

//            if (string.IsNullOrEmpty(password)) {
//                throw new MembershipCreateUserException(MembershipCreateStatus.InvalidPassword);
//            }
            
//            string hashedPassword = Crypto.HashPassword(password);
//            if (hashedPassword.Length > 128) {
//                throw new MembershipCreateUserException(MembershipCreateStatus.InvalidPassword);
//            }

//            if(string.IsNullOrEmpty(userName)){
//                throw new MembershipCreateUserException(MembershipCreateStatus.InvalidUserName);
//            }

//            using (var db = new Database()){
//                // 1) Check if user is in User Table
//                int uid = GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, userName);
//                if(uid==-1){
//                    throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
//                }

//                // 2) Check if user exists in Membership Table
//                var result = db.QuerySingle(@"SELECT COUNT(*) FROM [Memberhip] WHERE UserId = @0", uid);
//                if(result[0] >0){
//                    throw new MembershipCreateUserException(MembershipCreateStatus.DuplicateUserName);
//                }

//                // 3) Create user in Membership Table
//                string token = null;
//                object dbtoken = DBNull.Value;
//                if(requireConfirmationToken){
//                    token=GenerateToken();
//                    dbtoken=token;
//                }
//                int defaultNumPasswordFailures = 0;


//                int insert = db.Execute(@"INSERT INTO [Membership] (UserId, [Password], PasswordSalt, IsConfirmed, ConfirmationToken, CreateDate, PasswordChangedDate, PasswordFailuresSinceLastSuccess)"
//                                        + " VALUES (@0, @1, @2, @3, @4, @5, @5, @6)", uid, hashedPassword, String.Empty /* salt column is unused */, !requireConfirmationToken, dbtoken, DateTime.UtcNow, defaultNumPasswordFailures);

//                if (insert !=1){
//                    throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
//                }
//                return token;
//            }
//        }


//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status) {
//            if (!InitializeCalled) {
//                return PreviousProvider.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
//            }

//            throw new NotSupportedException();
//        }

//        private void CreateUserRow(Database db, string userName, IDictionary<string, object> values) {
//            // Make sure user doesn't exist
//            int userId = GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, userName);
//            if (userId != -1) {
//                throw new MembershipCreateUserException(MembershipCreateStatus.DuplicateUserName);
//            }

//            StringBuilder columnString = new StringBuilder();
//            columnString.Append(SafeUserNameColumn);
//            StringBuilder argsString = new StringBuilder();
//            argsString.Append("@0");
//            List<object> argsArray = new List<object>();
//            argsArray.Add(userName);
//            if (values != null) {
//                int index = 1;
//                foreach (string key in values.Keys) {
//                    // Skip the user name column since we always generate that
//                    if (String.Equals(UserNameColumn, key, StringComparison.OrdinalIgnoreCase)) {
//                        continue;
//                    }
//                    columnString.Append(",").Append(key);
//                    argsString.Append(",@").Append(index++);
//                    object value = values[key];
//                    if (value == null) {
//                        value = DBNull.Value;
//                    }
//                    argsArray.Add(value);
//                }
//            }
            
//            int rows = db.Execute("INSERT INTO " + SafeUserTableName + " (" + columnString.ToString() + ") VALUES (" + argsString.ToString() + ")", argsArray.ToArray());
//            if (rows != 1) {
//                throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
//            }
//        }

//        public override string CreateUserAndAccount(string userName, string password, bool requireConfirmation, IDictionary<string, object> values) {
//            VerifyInitialized();

//            using (var db = new Database()) {
//                CreateUserRow(db, userName, values);
//                return CreateAccount(userName, password, requireConfirmation);
//            }
//        }

//        public override bool DeleteAccount(string userName) {
//            VerifyInitialized();

//            using (var db = new Database()) {
//                int userId = GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, userName);
//                if (userId == -1) {
//                    return false; // User not found
//                }

//                int deleted = db.Execute(@"DELETE FROM Membership WHERE UserId = @0", userId);
//                return (deleted == 1);
//            }
//        }

//        public override bool DeleteUser(string username, bool deleteAllRelatedData) {
//            if (!InitializeCalled) {
//                return PreviousProvider.DeleteUser(username, deleteAllRelatedData);
//            }

//            using (var db = new Database()) {
//                int userId = GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, username);
//                if (userId == -1) {
//                    return false; // User not found
//                }

//                int deleted = db.Execute(@"DELETE FROM " + SafeUserTableName + " WHERE " + SafeUserIdColumn + " = @0", userId);
//                bool returnValue = (deleted == 1);

//                //if (deleteAllRelatedData) {
//                // REVIEW: do we really want to delete from the user table?
//                //}
//                return returnValue;
//            }
//        }

//        public override string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow) {
//            VerifyInitialized();
//            if (string.IsNullOrEmpty(userName)) {
//                throw new ArgumentException();
//            }
//            using (var db = new Database()) {
//                int userId = VerifyUserNameHasConfirmedAccount(db, userName, throwException: true);

//                string token = db.QueryValue(@"SELECT PasswordVerificationToken FROM Membership WHERE (UserId = @0 AND PasswordVerificationTokenExpirationDate > @1)", userId, DateTime.UtcNow);
//                if (token == null) {
//                    token = GenerateToken();

//                    int rows = db.Execute(@"UPDATE Membership SET PasswordVerificationToken = @0, PasswordVerificationTokenExpirationDate = @1 WHERE (UserId = @2)", token, DateTime.UtcNow.AddMinutes(tokenExpirationInMinutesFromNow), userId);
//                    if (rows != 1) {
//                        throw new ProviderException();
//                    }
//                }
//                else {
//                    // TODO: should we update expiry again?
//                }
//                return token;
//            }
//        }

//        public override bool ResetPasswordWithToken(string token, string newPassword) {
//            VerifyInitialized();
//            if (string.IsNullOrEmpty(newPassword)) {
//                throw new ArgumentException();
//            }
//            using (var db = new Database()) {
//                int? userId = db.QueryValue(@"SELECT UserId FROM " + MembershipTableName + " WHERE (PasswordVerificationToken = @0 AND PasswordVerificationTokenExpirationDate > @1)", token, DateTime.UtcNow);
//                if (userId != null) {
//                    bool success = SetPassword(db, userId.Value, newPassword);
//                    if (success) {
//                        // Clear the Token on success
//                        int rows = db.Execute(@"UPDATE " + MembershipTableName + " SET PasswordVerificationToken = NULL, PasswordVerificationTokenExpirationDate = NULL WHERE (UserId = @0)", userId);
//                        if (rows != 1) {
//                            throw new ProviderException();
//                        }
//                    }
//                    return success;
//                }
//                else {
//                    return false;
//                }
//            }
//        }

//        public override void UpdateUser(MembershipUser user) {
//            if (!InitializeCalled) {
//                PreviousProvider.UpdateUser(user);
//            }
//            else {
//                throw new NotSupportedException();
//            }
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override bool UnlockUser(string userName) {
//            if (!InitializeCalled) {
//                return PreviousProvider.UnlockUser(userName);
//            }
//            throw new NotSupportedException();
//        }

//        private static string GenerateToken()
//        {
//            using (var prng = new RNGCryptoServiceProvider())
//            {
//                return GenerateToken(prng);
//            }
//        }

//        internal static string GenerateToken(RandomNumberGenerator generator)
//        {
//            byte[] tokenBytes = new byte[TokenSizeInBytes];
//            generator.GetBytes(tokenBytes);
//            return HttpServerUtility.UrlTokenEncode(tokenBytes);
//        }

//        #endregion

//        #region Queries
//        // Queries

//        /// <summary>
//        /// Sets the confirmed flag for the username if it is correct.
//        /// </summary>
//        /// <returns>True if the account could be successfully confirmed. False if the username was not found or the confirmation token is invalid.</returns>
//        /// <remarks>Inherited from ExtendedMembershipProvider ==> Simple Membership MUST be enabled to use this method.
//        /// There is a tiny possibility where this method fails to work correctly. Two or more users could be assigned the same token but specified using different cases.
//        /// A workaround for this would be to use the overload that accepts both the user name and confirmation token.
//        /// </remarks>
//        public override bool ConfirmAccount(string accountConfirmationToken) {
//            VerifyInitialized();
//            using (var db = new Database()) {
//                // We need to compare the token using a case insensitive comparison however it seems tricky to do this uniformly across databases when representing the token as a string. 
//                // Therefore verify the case on the client
//                var rows = db.Query("SELECT [UserId], [ConfirmationToken] FROM " + MembershipTableName + " WHERE [ConfirmationToken] = @0", accountConfirmationToken)
//                    .Where(r => ((string)r[1]).Equals(accountConfirmationToken, StringComparison.Ordinal))
//                    .ToList();
//                Debug.Assert(rows.Count < 2, "By virtue of the fact that the ConfirmationToken is random and unique, we can never have two tokens that are identical.");
//                if (!rows.Any()) {
//                    return false;
//                }
//                var row = rows.First();
//                int userId = row[0];
//                int affectedRows = db.Execute("UPDATE " + MembershipTableName + " SET [IsConfirmed] = 1 WHERE [UserId] = @0", userId);
//                return affectedRows > 0;
//            }
//        }

//        /// <summary>
//        /// Sets the confirmed flag for the username if it is correct.
//        /// </summary>
//        /// <returns>True if the account could be successfully confirmed. False if the username was not found or the confirmation token is invalid.</returns>
//        /// <remarks>Inherited from ExtendedMembershipProvider ==> Simple Membership MUST be enabled to use this method</remarks>
//        public override bool ConfirmAccount(string userName, string accountConfirmationToken) {
//            VerifyInitialized();
//            using (var db = new Database()) {
//                // We need to compare the token using a case insensitive comparison however it seems tricky to do this uniformly across databases when representing the token as a string. 
//                // Therefore verify the case on the client
//                var row = db.QuerySingle("SELECT m.[UserId], m.[ConfirmationToken] FROM " + MembershipTableName + " m JOIN " + SafeUserTableName + " u"
//                                         + " ON m.[UserId] = u." + SafeUserIdColumn
//                                         + " WHERE m.[ConfirmationToken] = @0 AND"
//                                         + " u." + SafeUserNameColumn + " = @1", accountConfirmationToken, userName);
//                if (row == null) {
//                    return false;
//                }
//                int userId = row[0];
//                string expectedToken = row[1];

//                if (String.Equals(accountConfirmationToken, expectedToken, StringComparison.Ordinal)) {
//                    int affectedRows = db.Execute("UPDATE " + MembershipTableName + " SET [IsConfirmed] = 1 WHERE [UserId] = @0", userId);
//                    return affectedRows > 0;
//                }
//                return false;
//            }
//        }

//        public override ICollection<OAuthAccountData> GetAccountsForUser(string userName) {
//            VerifyInitialized();

//            int userId = GetUserId(userName);
//            if (userId != -1) {
//                using (var db = new Database()) {
//                    IEnumerable<dynamic> records = db.Query(@"SELECT Provider, ProviderUserId FROM [" + OAuthMembershipTableName + "] WHERE UserId=@0", userId);
//                    if (records != null) {
//                        var accounts = new List<OAuthAccountData>();
//                        foreach (DynamicRecord row in records) {
//                            accounts.Add(new OAuthAccountData((string)row["Provider"], (string)row["ProviderUserId"]));
//                        }
//                        return accounts;
//                    }
//                }
//            }

//            return new OAuthAccountData[0];
//        }

//        public override DateTime GetCreateDate(string userName) {
//            using (var db = new Database()) {
//                int userId = GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, userName);
//                if (userId == -1) {
//                    throw new InvalidOperationException();
//                }

//                var createDate = db.QueryValue(@"SELECT CreateDate FROM " + MembershipTableName + " WHERE (UserId = @0)", userId);
//                if (createDate != null) {
//                    return createDate;
//                }
//                return DateTime.MinValue;
//            }
//        }

//        public override DateTime GetLastPasswordFailureDate(string userName) {
//            using (var db = new Database()) {
//                int userId = GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, userName);
//                if (userId == -1) {
//                    throw new InvalidOperationException();
//                }

//                var failureDate = db.QuerySingle(@"SELECT LastPasswordFailureDate FROM " + MembershipTableName + " WHERE (UserId = @0)", userId);
//                if (failureDate != null && failureDate[0] != null) {
//                    return (DateTime)failureDate[0];
//                }
//                return DateTime.MinValue;
//            }
//        }

//        // Inherited from MembershipProvider ==> Forwarded to previous provider if this provider hasn't been initialized
//        public override string GetPassword(string username, string answer) {
//            if (!InitializeCalled) {
//                return PreviousProvider.GetPassword(username, answer);
//            }
//            throw new NotSupportedException();
//        }

//        public override DateTime GetPasswordChangedDate(string userName) {
//            using (var db = new Database()) {
//                int userId = GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, userName);
//                if (userId == -1) {
//                    throw new InvalidOperationException();
//                }

//                var pwdChangeDate = db.QuerySingle(@"SELECT PasswordChangedDate FROM " + MembershipTableName + " WHERE (UserId = @0)", userId);
//                if (pwdChangeDate != null && pwdChangeDate[0] != null) {
//                    return (DateTime)pwdChangeDate[0];
//                }
//                return DateTime.MinValue;
//            }
//        }

//        // Inherited from ExtendedMembershipProvider ==> Simple Membership MUST be enabled to use this method
//        public override int GetUserIdFromPasswordResetToken(string token) {
//            VerifyInitialized();
//            using (var db = new Database()) {
//                var result = db.QuerySingle(@"SELECT UserId FROM " + MembershipTableName + " WHERE (PasswordVerificationToken = @0)", token);
//                if (result != null && result[0] != null) {
//                    return (int)result[0];
//                }
//                return -1;
//            }
//        }

//        public override bool IsConfirmed(string userName) {
//            VerifyInitialized();
//            if (string.IsNullOrEmpty(userName)) {
//                throw new ArgumentException();
//            }

//            using (var db = new Database()) {
//                int userId = VerifyUserNameHasConfirmedAccount(db, userName, throwException: false);
//                return (userId != -1);
//            }
//        }

//        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords) {
//            if (!InitializeCalled) {
//                return PreviousProvider.FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords);
//            }
//            throw new NotSupportedException();
//        }

//        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords) {
//            if (!InitializeCalled) {
//                return PreviousProvider.FindUsersByName(usernameToMatch, pageIndex, pageSize, out totalRecords);
//            }
//            throw new NotSupportedException();
//        }

//        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords) {
//            if (!InitializeCalled) {
//                return PreviousProvider.GetAllUsers(pageIndex, pageSize, out totalRecords);
//            }
//            throw new NotSupportedException();
//        }

//        public override int GetNumberOfUsersOnline() {
//            if (!InitializeCalled) {
//                return PreviousProvider.GetNumberOfUsersOnline();
//            }
//            throw new NotSupportedException();
//        }

//        public override MembershipUser GetUser(string username, bool userIsOnline) {
//            if (!InitializeCalled) {
//                return PreviousProvider.GetUser(username, userIsOnline);
//            }

//            // Due to a bug in v1, GetUser allows passing null / empty values.
//            using (var db = new Database()) {
//                int userId = GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, username);
//                if (userId == -1) {
//                    return null; // User not found
//                }

//                return new MembershipUser(Membership.Provider.Name, username, userId, null, null, null, true, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
//            }
//        }

//        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline) {
//            if (!InitializeCalled) {
//                return PreviousProvider.GetUser(providerUserKey, userIsOnline);
//            }
//            throw new NotSupportedException();
//        }

//        public override string GetUserNameByEmail(string email) {
//            if (!InitializeCalled) {
//                return PreviousProvider.GetUserNameByEmail(email);
//            }
//            throw new NotSupportedException();
//        }

//        public override string ResetPassword(string username, string answer) {
//            if (!InitializeCalled) {
//                return PreviousProvider.ResetPassword(username, answer);
//            }
//            throw new NotSupportedException();
//        }

//        public override bool ValidateUser(string username, string password) {
//            if (!InitializeCalled) {
//                return PreviousProvider.ValidateUser(username, password);
//            }
//            if (string.IsNullOrEmpty(username)) {
//                throw new ArgumentException();
//            }
//            if (string.IsNullOrEmpty(password)) {
//                throw new ArgumentException();
//            }

//            using (var db = new Database()) {
//                int userId = VerifyUserNameHasConfirmedAccount(db, username, throwException: false);
//                if (userId == -1) {
//                    return false;
//                }
//                else {
//                    return CheckPassword(db, userId, password);
//                }
//            }
//        }

//        // Not an override ==> Simple Membership MUST be enabled to use this method
//        public int GetUserId(string userName) {
//            VerifyInitialized();
//            using (var db = new Database()) {
//                return GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, userName);
//            }
//        }
//        internal static int GetUserId(Database db, string userTableName, string userNameColumn, string userIdColumn, string userName) {
//            // Casing is normalized in Sql to allow the database to normalize username according to its collation. The common issue 
//            // that can occur here is the 'Turkish i problem', where the uppercase of 'i' is not 'I' in Turkish.
//            var result = db.QueryValue(@"SELECT " + userIdColumn + " FROM " + userTableName + " WHERE (UPPER(" + userNameColumn + ") = UPPER(@0))", userName);
//            if (result != null) {
//                return (int)result;
//            }
//            return -1;
//        }

//        internal void VerifyInitialized() {
//            if (!InitializeCalled) {
//                throw new InvalidOperationException();
//            }
//        }

//        private bool CheckPassword(Database db, int userId, string password)
//        {
//            string hashedPassword = GetHashedPassword(db, userId);
//            bool verificationSucceeded = (hashedPassword != null && Crypto.VerifyHashedPassword(hashedPassword, password));
//            if (verificationSucceeded)
//            {
//                // Reset password failure count on successful credential check
//                db.Execute(@"UPDATE Membership SET PasswordFailuresSinceLastSuccess = 0 WHERE (UserId = @0)", userId);
//            }
//            else
//            {
//                int failures = GetPasswordFailuresSinceLastSuccess(db, userId);
//                if (failures != -1)
//                {
//                    db.Execute(@"UPDATE Membership SET PasswordFailuresSinceLastSuccess = @1, LastPasswordFailureDate = @2 WHERE (UserId = @0)", userId, failures + 1, DateTime.UtcNow);
//                }
//            }
//            return verificationSucceeded;
//        }

//        private string GetHashedPassword(Database db, int userId) {
//            var pwdQuery = db.Query(@"SELECT m.[Password] " +
//                                    @"FROM Membership m, " + SafeUserTableName + " u " +
//                                    @"WHERE m.UserId = " + userId + " AND m.UserId = u." + SafeUserIdColumn).ToList();
//            // REVIEW: Should get exactly one match, should we throw if we get > 1?
//            if (pwdQuery.Count != 1) {
//                return null;
//            }
//            return pwdQuery[0].Password;
//        }
        
//        private static int GetPasswordFailuresSinceLastSuccess(Database db, int userId) {
//            var failure = db.QueryValue(@"SELECT PasswordFailuresSinceLastSuccess FROM Membership WHERE (UserId = @0)", userId);
//            if (failure != null) {
//                return failure;
//            }
//            return -1;
//        }

//        // Inherited from ExtendedMembershipProvider ==> Simple Membership MUST be enabled to use this method
//        public override int GetPasswordFailuresSinceLastSuccess(string userName) {
//            using (var db = new Database()) {
//                int userId = GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, userName);
//                if (userId == -1) {
//                    throw new InvalidOperationException();
//                }

//                return GetPasswordFailuresSinceLastSuccess(db, userId);
//            }
//        }

//        private int VerifyUserNameHasConfirmedAccount(Database db, string username, bool throwException) {
//            int userId = GetUserId(db, SafeUserTableName, SafeUserNameColumn, SafeUserIdColumn, username);
//            if (userId == -1) {
//                if (throwException) {
//                    throw new InvalidOperationException();
//                }
//                else {
//                    return -1;
//                }
//            }

//            int result = db.QueryValue(@"SELECT COUNT(*) FROM Membership WHERE (UserId = @0 AND IsConfirmed = 1)", userId);
//            if (result == 0) {
//                if (throwException) {
//                    throw new InvalidOperationException();
//                }
//                else {
//                    return -1;
//                }
//            }
//            return userId;
//        }

//        #endregion
//    }
//}