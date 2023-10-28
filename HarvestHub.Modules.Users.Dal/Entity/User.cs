namespace HarvestHub.Modules.Users.Dal.Entity
{
    public sealed class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Guid VerificationToken { get; set; }
        public Guid? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }

        public User(Guid id, string firstName, string lastName, 
                    string email, DateTime createdAt, DateTime? verifiedAt, 
                    byte[] passwordHash, byte[] passwordSalt, Guid verificationToken, 
                    Guid? passwordResetToken, DateTime? resetTokenExpires
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedAt = createdAt;
            VerifiedAt = verifiedAt;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            VerificationToken = verificationToken;
            PasswordResetToken = passwordResetToken;
            ResetTokenExpires = resetTokenExpires;
        }
    }
}
