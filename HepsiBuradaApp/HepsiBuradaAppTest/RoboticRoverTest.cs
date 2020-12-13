using System;
using Xunit;
using HepsiBuradaApp;

namespace HepsiBuradaAppTest
{
    public class RoboticRoverTest
    {
        public Plateau plateau = new Plateau(10, 10);
        [Fact]
        public void TurnLeft_IfDirectionN_ReturnsW()
        {
            var rover = new RoboticRover(1, 1, CompassPoints.N, plateau);
            rover.TurnLeft();
            Assert.False(rover.Direction != CompassPoints.W, "If direction is north, after turning left the direction should be west.");
        }
        [Fact]
        public void TurnLeft_IfDirectionW_ReturnsS()
        {
            var rover = new RoboticRover(1, 1, CompassPoints.W, plateau);
            rover.TurnLeft();
            Assert.False(rover.Direction != CompassPoints.S, "If direction is west, after turning left the direction should be south.");
        }
        [Fact]
        public void TurnLeft_IfDirectionS_ReturnsE()
        {
            var rover = new RoboticRover(1, 1, CompassPoints.S, plateau);
            rover.TurnLeft();
            Assert.False(rover.Direction != CompassPoints.E, "If direction is south, after turning left the direction should be east.");
        }
        [Fact]
        public void TurnLeft_IfDirectionE_ReturnsN()
        {
            var rover = new RoboticRover(1, 1, CompassPoints.E, plateau);
            rover.TurnLeft();
            Assert.False(rover.Direction != CompassPoints.N, "If direction is east, after turning left the direction should be north.");
        }

        [Fact]
        public void TurnRight_IfDirectionN_ReturnsE()
        {
            var rover = new RoboticRover(1, 1, CompassPoints.N, plateau);
            rover.TurnRight();
            Assert.False(rover.Direction != CompassPoints.E, "If direction is north, after turning right the direction should be east.");
        }

        [Fact]
        public void TurnRight_IfDirectionE_ReturnsS()
        {
            var rover = new RoboticRover(1, 1, CompassPoints.E, plateau);
            rover.TurnRight();
            Assert.False(rover.Direction != CompassPoints.S, "If direction is east, after turning right the direction should be south.");
        }

        [Fact]
        public void TurnRight_IfDirectionS_ReturnsW()
        {
            var rover = new RoboticRover(1, 1, CompassPoints.S, plateau);
            rover.TurnRight();
            Assert.False(rover.Direction != CompassPoints.W, "If direction is south, after turning right the direction should be west.");
        }

        [Fact]
        public void TurnRight_IfDirectionW_ReturnsN()
        {
            var rover = new RoboticRover(1, 1, CompassPoints.W, plateau);
            rover.TurnRight();
            Assert.False(rover.Direction != CompassPoints.N, "If direction is west, after turning right the direction should be north.");
        }

        [Fact]
        public void Move_IfDirectionN_ReturnsYPlus1()
        {
            var rover = new RoboticRover(2, 0, CompassPoints.N, plateau);
            rover.Move();
            Assert.False(rover.CurrentCoordinate.Y != 1, "If direction is north, after move the Y should be 1.");
            Assert.False(rover.CurrentCoordinate.X != 2, "If direction is north, after move the X should be 2.");
        }

        [Fact]
        public void Move_IfDirectionE_ReturnsXPlus1()
        {
            var rover = new RoboticRover(1, 1, CompassPoints.E, plateau);
            rover.Move();
            Assert.False(rover.CurrentCoordinate.Y != 1, "If direction is east, after move the Y should be 1.");
            Assert.False(rover.CurrentCoordinate.X != 2, "If direction is east, after move the X should be 2.");
        }

        [Fact]
        public void Move_IfDirectionS_ReturnsYMinus1()
        {
            var rover = new RoboticRover(1, 1, CompassPoints.S, plateau);
            rover.Move();
            Assert.False(rover.CurrentCoordinate.Y != 0, "If direction is south, after move the Y should be 0.");
            Assert.False(rover.CurrentCoordinate.X != 1, "If direction is south, after move the X should be 1.");
        }

        [Fact]
        public void Move_IfDirectionW_ReturnsXMinus1()
        {
            var rover = new RoboticRover(2, 0, CompassPoints.W, plateau);
            rover.Move();
            Assert.False(rover.CurrentCoordinate.Y != 0, "If direction is north, after move the Y should be 0.");
            Assert.False(rover.CurrentCoordinate.X != 1, "If direction is north, after move the X should be 1.");
        }

        [Fact]
        public void ApplyCommands_InputIsLMLMLMLMMWithRover12N_Returns13N()
        {
            var rover = new RoboticRover(1, 2, CompassPoints.N, plateau);
            rover.ApplyCommands(new char[] { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M' });

            Assert.False(rover.CurrentCoordinate.X != 2, "If rover current coordinate is 1 2 north and commands are LMLMLMLMM, after ApplyCommands the X should be 1.");
            Assert.False(rover.CurrentCoordinate.Y != 2, "If rover current coordinate is 1 2 north and commands are LMLMLMLMM, after ApplyCommands the Y should be 3.");
            Assert.False(rover.Direction != CompassPoints.N, "If rover current coordinate is 1 2 north and commands are LMLMLMLMM, after ApplyCommands the direction should be north.");
        }

        [Fact]
        public void ApplyCommands_InputIsMMRMMRMRRMWithRover33E_Returns51E()
        {
            var rover = new RoboticRover(3, 3, CompassPoints.E, plateau);
            rover.ApplyCommands(new char[] { 'M', 'M', 'R', 'M', 'M', 'R', 'M', 'R', 'R', 'M' });

            Assert.False(rover.CurrentCoordinate.X != 5, "If rover current coordinate is 3 3 east and commands are MMRMMRMRRM, after ApplyCommands the X should be 5.");
            Assert.False(rover.CurrentCoordinate.Y != 1, "If rover current coordinate is 3 3 east and commands are MMRMMRMRRM, after ApplyCommands the Y should be 1.");
            Assert.False(rover.Direction != CompassPoints.E, "If rover current coordinate is 3 3 east and commands are MMRMMRMRRM, after ApplyCommands the direction should be east.");
        }
    }
}
