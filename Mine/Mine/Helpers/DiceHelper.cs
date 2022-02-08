using System;

namespace Mine.Helpers
{
    /// <summary>
    /// The DiceHelper class
    /// </summary>
    public static class DiceHelper
    {
        // Static random value
        private static Random rnd = new Random();

        // Boolean Flag to Force Rolls to Not be Random
        public static bool ForceRollsToNotRandom = false;

        // Defining the Forced Value
        public static int ForcedRandomValue = 1;

        public static int RollDice(int rolls, int dice)
        {
            // Check if flag has been set to true
            if (ForceRollsToNotRandom)
            {
                return rolls * ForcedRandomValue;
            }

            // Check if rolls is less than 1
            if (rolls < 1)
            {
                return 0;
            }

            // Check if dice is less than 1
            if (dice < 1)
            {
                return 0;
            }

            // Variable to store die roll results
            var myReturn = 0;

            // Roll dice the indicated number of times and sum the values
            for (var i = 0; i < rolls; i++)
            {
                myReturn += rnd.Next(1, dice + 1);
            }

            return myReturn;
        }

    }
}
