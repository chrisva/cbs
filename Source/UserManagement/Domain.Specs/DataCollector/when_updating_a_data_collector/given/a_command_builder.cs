/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts;
using Domain.DataCollectors;

namespace Domain.Specs.DataCollector.when_updating_a_data_collector.given
{
    public class a_command_builder
    {
        public static RegisterDataCollector get_valid_command()
         {
             return new RegisterDataCollector()
             {
                DataCollectorId = Guid.NewGuid(),
                FullName = "Data Collector",
                DisplayName = "DisplayName",
                YearOfBirth = 1984,
                Sex = Sex.Male,
                PreferredLanguage = Language.English,
                GpsLocation = new Location(90,90),
                PhoneNumbers = new [] {"123456789"},
                Region = "Region",
                District = "District",
                DataVerifierId = Guid.NewGuid()
            };
         }

         public static RegisterDataCollector get_invalid_command(IEnumerable<Action<RegisterDataCollector>> invalidations)
         {
             var cmd = get_valid_command();
             foreach(var invalidate in invalidations)
             {
                 invalidate(cmd);
             }
             return cmd;
         }


         public static RegisterDataCollector get_invalid_command(Action<RegisterDataCollector> invalidate)
         {
             return get_invalid_command(new []{ invalidate });
         }
    }
}