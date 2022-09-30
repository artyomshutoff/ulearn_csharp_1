using System;
using NUnit.Framework;

namespace Manipulation {
public static class ManipulatorTask
{
    public static double[] MoveManipulatorTo(double x, double y, double angle)
    {
        var wristAxisY = y + Math.Sin(Math.PI - angle) * Manipulator.Palm;
        var wristAxisX = x + Math.Cos(Math.PI - angle) * Manipulator.Palm;
        var length =
          Math.Sqrt(wristAxisY * wristAxisY + wristAxisX * wristAxisX);
        var elbow = TriangleTask.GetABAngle(
          Manipulator.UpperArm, Manipulator.Forearm, length);
        var shoulder = TriangleTask.GetABAngle(
                         Manipulator.UpperArm, length, Manipulator.Forearm) +
                       Math.Atan2(wristAxisY, wristAxisX);
        var wrist = 3 * Math.PI - shoulder - elbow - angle - Math.PI;

        return new[]{ shoulder, elbow, wrist };
    }
}

[TestFixture]
public class ManipulatorTask_Tests
{
    [Test]
    public void
    TestMoveManipulatorTo()
    {
        var random = new Random();
        for (var i = 0; i < 1000; i++) {
            var x = random.NextDouble();
            var y = random.NextDouble();
            var angleAlpha = random.NextDouble() * Math.PI;
            var angle = ManipulatorTask.MoveManipulatorTo(x, y, angleAlpha);
            var joints = AnglesToCoordinatesTask.GetJointPositions(
              angle[0], angle[1], angle[2]);
            Assert.AreEqual(joints[2].X, x, 1e-4);
            Assert.AreEqual(joints[2].Y, y, 1e-4);
        }
    }
}
}