using NSubstitute;
using NUnit.Framework;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Test]
        public void ShouldTurnAlarmOn()
        {
            var sensor = Substitute.For<ISensor>();
            sensor.PopNextPressurePsiValue().Returns(1);
            var alarm = new AlarmWithFakeSensor(sensor);

            alarm.Check();

            Assert.IsTrue(alarm.AlarmOn);
        }
    }

    public class AlarmWithFakeSensor :Alarm
    {
        private ISensor sensor;

        public AlarmWithFakeSensor(ISensor sensor)
        {
            this.sensor = sensor;
        }

        protected override ISensor CreateSensor()
        {
            return sensor;
        }
    }
}