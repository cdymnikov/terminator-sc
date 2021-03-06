﻿using System;
using System.Configuration;
using System.Linq;
using SharpDX.DirectInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Terminator.Device.Input.DirectX;
using Terminator.Device.Input;
using Terminator.Device.Output;
using Terminator.Device.Output.Joystick;
using System.Threading;
using Terminator;

namespace Terminator.Tests
{
    [TestClass]
    public class When_starting_and_stopping_loop_manager
    {
        private readonly Resolver _resolver = new Resolver();

        private bool _flag = false;

        [TestMethod]
        public void Action_runs_multiple_times_and_stops_after_dispose()
        {
            using (var manager = _resolver.Resolve<ILoopManager>())
            {
                manager.Start(CheckAndIncrement);

                _flag = true;
                while (_flag) { }

                _flag = true;
                while (_flag) { }
            }

            _flag = true;
            Assert.IsTrue(_flag);
        }

        private void CheckAndIncrement()
        {
            if (_flag)
            {
                _flag = false;
            }
        }
    }
}
