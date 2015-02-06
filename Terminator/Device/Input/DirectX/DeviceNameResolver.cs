using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace Terminator.Device.Input.DirectX
{
    public class DeviceNameResolver : IDeviceNameResolver
    {
        private readonly DeviceType[] _allDeviceTypes = new DeviceType[] { DeviceType.ControlDevice, DeviceType.Device, DeviceType.Driving, DeviceType.FirstPerson, DeviceType.Flight, DeviceType.Gamepad, DeviceType.Joystick, DeviceType.Keyboard, DeviceType.Mouse, DeviceType.Remote, DeviceType.ScreenPointer, DeviceType.Supplemental };

        private readonly DirectInput _directInput;

        public DeviceNameResolver(DirectInput directInput)
        {
            _directInput = directInput;
        }

        public Guid Resolve(Identifier id)
        {
            return GetAllDevices(_allDeviceTypes)
                .Where(x => x.ProductName == id.ProductName)
                .Select(x => x.InstanceGuid)
                .ToList()[id.Number];
        }

        private IEnumerable<DeviceInstance> GetAllDevices(params DeviceType[] deviceTypes)
        {
            foreach (var deviceType in deviceTypes)
            {
                foreach (var device in _directInput.GetDevices(deviceType, DeviceEnumerationFlags.AllDevices))
                {
                    yield return device;
                }
            }
        }
    }
}
