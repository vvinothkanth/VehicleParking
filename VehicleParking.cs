//===================================
// Problem Title : Vehicle Parking
// Starting Date : 11/ 9 / 2018
//
//
//
//===================================

namespace VehiclePark
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public class VehicleParking
    {
        /// <summary>
        /// The level collections
        /// </summary>
        public Dictionary<int, Level> parkingLevels = new Dictionary<int, Level>();

        /// <summary>
        /// The collection of tokens
        /// </summary>
        public Dictionary<int, Token> tokens = new Dictionary<int, Token>();

        /// <summary>
        /// To create new level
        /// </summary>
        /// <returns></returns>
        public int CreateLevel()
        {
            int levelId = 0;
            try
            {
                if (parkingLevels.Count != 0)
                {
                    levelId = parkingLevels.Keys.Max() + 1;
                }
                else
                {
                    levelId = parkingLevels.Count + 1;
                }

                Level level = new Level();
                parkingLevels.Add(levelId, level);

            }
            catch (Exception)
            {
                
                throw;
            }


            return levelId;
        }

        /// <summary>
        /// To create token
        /// </summary>
        /// <param name="levelId">Level Id</param>
        /// <param name="parkingId">Parking Id</param>
        /// <returns></returns>
        public int CreateToken(int levelId, int parkingId)
        {
            int tokenNumber = 0;

            try
            {
                Token token = new Token();
                token.levelId = levelId;
                token.ParkedId = parkingId;
                tokens.Add(tokens.Count + 1, token);
                tokenNumber = tokens.Count;
            }
            catch (Exception)
            { 
                throw;
            }

            return tokenNumber;
            
        }

        /// <summary>
        /// To get all levels
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Level> GetAllLevel()
        {
            return parkingLevels;
        }
    }
}
