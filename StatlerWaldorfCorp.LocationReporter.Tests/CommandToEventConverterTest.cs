﻿using System;
using System.Collections.Generic;
using System.Text;
using StatlerWaldorfCorp.LocationReporter.Events;
using StatlerWaldorfCorp.LocationReporter.Models;
using Xunit;


namespace StatlerWaldorfCorp.LocationReporter.Tests
{
    public class CommandToEventConverterTest
    {
        [Fact]
        public void AugmentsCommandWithTimestamp()
        {
            long startTime = DateTime.Now.ToUniversalTime().Ticks;
            LocationReport command = new LocationReport
            {
                Latitude = 10.0,
                Longitude = 30.0,
                Origin = "TESTS",
                MemberID = Guid.NewGuid()
            };
            CommandEventConverter converter = new CommandEventConverter();
            MemberLocationRecordedEvent recordedEvent = converter.CommandToEvent(command);

            Assert.Equal(command.Latitude, recordedEvent.Latitude);
            Assert.Equal(command.Longitude, recordedEvent.Longitude);
            Assert.Equal(command.Origin, recordedEvent.Origin);
            Assert.True(recordedEvent.RecordedTime >= startTime);
        }
    }

}
