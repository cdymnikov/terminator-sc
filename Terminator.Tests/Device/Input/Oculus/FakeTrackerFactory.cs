using System.Reflection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Terminator.Device;
using Terminator.Device.Input;
using Terminator.Device.Input.Oculus;
using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using SharpOVR;

namespace Terminator.Device.Input.Oculus
{
    class FakeTrackerFactory : IHeadTrackerFactory
    {
        private readonly FakeTracker _tracker;

        public FakeTrackerFactory(FakeTracker tracker)
        {
            _tracker = tracker;
        }

        public IHeadTracker Create(Identifier id)
        {
            return _tracker;
        }
    }

    class FakeTracker : IHeadTracker
    {
        public PoseF Right { get; set; }
        public PoseF Left { get; set; }

        public PoseF ReadLeftEye()
        {
            return Left;
        }

        public PoseF ReadRightEye()
        {
            return Right;
        }
    }
}

