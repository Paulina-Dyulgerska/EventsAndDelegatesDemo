using System;

namespace Problem05
{
    public interface ICanFight : IAmNational
    {
        event EventHandler<SolderEventArgs> SolderKilled;

        event EventHandler<SolderEventArgs> SolderRespondedOnKingAttack;

        bool IsDead { get; }

        void Die();

        void OnKingAttackedHandler(object sender, KingAttackedEventArgs args);
    }
}
