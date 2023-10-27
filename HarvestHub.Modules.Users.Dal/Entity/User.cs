namespace HarvestHub.Modules.Users.Dal.Entity
{
    public sealed class User
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? VerifiedAt { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public Guid VerificationToken { get; private set; }
        public Guid PasswordResetToken { get; private set; }
        public DateTime? ResetTokenExpires { get; private set; }

        public User(Guid id, string firstName, string lastName, 
                    string email, DateTime createdAt, DateTime? verifiedAt, 
                    byte[] passwordHash, byte[] passwordSalt, Guid verificationToken, 
                    Guid passwordResetToken, DateTime? resetTokenExpires
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
