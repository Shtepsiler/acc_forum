using System;

namespace Forum_DAL.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository _userRepository { get; }
        IMessageRepository _messageRepository { get; }

        void Commit();
        void Dispose();
    }
}
