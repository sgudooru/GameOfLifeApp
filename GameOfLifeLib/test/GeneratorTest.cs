using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GameOfLifeLib
{
    [TestFixture]
    public class GeneratorTest
    {
        Generator _generator;

        [SetUp]
        public void CreateGenerator()
        {
            _generator = new Generator();
        }

        [Test]
        public void TestCanary()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestLiveCellWillDieWithZeroLiveNeighbours()
        {
            Assert.IsFalse(_generator.IsCellLiveInNextGeneration(true, 0));
        }

        [Test]
        public void TestLiveCellWillDieWithOneLiveNeighbour()
        {
            Assert.IsFalse(_generator.IsCellLiveInNextGeneration(true, 1));
        }

        [Test]
        public void TestLiveCellWillLiveWithTwoLiveNeighbours()
        {
            Assert.IsTrue(_generator.IsCellLiveInNextGeneration(true, 2));
        }

        [Test]
        public void TestLiveCellWillLiveWithThreeLiveNeighbours()
        {
            Assert.IsTrue(_generator.IsCellLiveInNextGeneration(true, 3));
        }

        [Test]
        public void TestLiveCellWillDieWithMoreThanThreeLiveNeighbours()
        {
            Assert.IsFalse(_generator.IsCellLiveInNextGeneration(true, 4));
        }

        [Test]
        public void TestDeadCellWillDieWithZeroLiveNeighbours()
        {
            Assert.IsFalse(_generator.IsCellLiveInNextGeneration(false, 0));
        }

        [Test]
        public void TestDeadCellWillNotLiveWithOneLiveNeighbour()
        {
            Assert.IsFalse(_generator.IsCellLiveInNextGeneration(false, 1));
        }

        [Test]
        public void TestDeadCellWillNotLiveWithTwoLiveNeighbours()
        {
            Assert.IsFalse(_generator.IsCellLiveInNextGeneration(false, 2));
        }

        [Test]
        public void TestDeadCellWillLiveWithThreeLiveNeighbours()
        {
            Assert.IsTrue(_generator.IsCellLiveInNextGeneration(false, 3));
        }

        [Test]
        public void TestDeadCellWillNotLiveWithMoreThanThreeLiveNeighbours()
        {
            Assert.IsFalse(_generator.IsCellLiveInNextGeneration(false, 4));
        }

        [Test]
        public void TestLiveCellWillDieWithLessThanZeroLiveNeighbours()
        {
            Assert.IsFalse(_generator.IsCellLiveInNextGeneration(true, -1));
        }

        [Test]
        public void TestLiveCellWillDieWithNineLiveNeighbours()
        {
            Assert.IsFalse(_generator.IsCellLiveInNextGeneration(true, 9));
        }

        [Test]
        public void TestDeadCellRemianDeadWithLessThanZeroLiveNeighbours()
        {
            Assert.IsFalse(_generator.IsCellLiveInNextGeneration(false, -1));
        }

        [Test]
        public void TestDeadCellWillRemainDeadWithNineLiveNeighbours()
        {
            Assert.IsFalse(_generator.IsCellLiveInNextGeneration(false, 9));
        }

        [Test]
        public void TestNumberOfNeighboursForEdgeCell()
        {
            Assert.AreEqual(5, _generator.GetNumberOfNeighbours(GameOfLifeHelper.CreatePattern(new int[2] { 3, 3 }, new int[5] { 0, 2, 3, 4, 5 }), 0, 1));
        }

        [Test]
        public void TestNumberOfNeighboursForCenterCell()
        {
            Assert.AreEqual(8, _generator.GetNumberOfNeighbours(GameOfLifeHelper.CreatePattern(new int[2] { 3, 3 }, new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }), 1, 1));
        }

        [Test]
        public void TestNumberOfNeighboursForOutOfBoundsCell()
        {
            Assert.AreEqual(0, _generator.GetNumberOfNeighbours(GameOfLifeHelper.CreatePattern(new int[2] { 3, 3 }, new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }), -1, 5));
        }

        [Test]
        public void TestNumberOfNeighboursForNullPattern()
        {
            Assert.AreEqual(0, _generator.GetNumberOfNeighbours(null, 3, 2));
        }

        [Test]
        public void TestAllDeadCellsWillRemainDead()
        {
            Assert.AreEqual(GameOfLifeHelper.CreatePattern(new int[2] { 3, 3 }), _generator.NextGeneration(GameOfLifeHelper.CreatePattern(new int[2] { 3, 3 })));
        }

        [Test]
        public void TestOneLiveCellWillGenerateAllDead()
        {
            Assert.AreEqual(new bool[3, 3], _generator.NextGeneration(GameOfLifeHelper.CreatePattern(new int[] { 3, 3 }, new int[] { 4 })));
        }

        [Test]
        public void TestTwoLiveCellsWillGenerateAllDead()
        {
            Assert.AreEqual(new bool[3, 3], _generator.NextGeneration(GameOfLifeHelper.CreatePattern(new int[] { 3, 3 }, new int[] { 4, 5 })));
        }

        [Test]
        public void TestNullWillGenerateNull()
        {
            Assert.AreEqual(null,_generator.NextGeneration(null));
        }

        [Test]
        public void TestForStillLifeBlockPattern()
        {
            bool[,] pattern = GameOfLifeHelper.CreatePattern(new int[] { 4, 4 }, new int[] { 5, 6, 9, 10 });

            Assert.AreEqual(pattern, _generator.NextGeneration(pattern));
        }

        [Test]
        public void TestForStillLifeBeehivePattern()
        {
            bool[,] pattern = GameOfLifeHelper.CreatePattern(new int[] { 5, 6 }, new int[] { 8, 9, 13, 16, 20, 21 });

            Assert.AreEqual(pattern, _generator.NextGeneration(pattern));
        }

        [Test]
        public void TestForStillLifeLoafPattern()
        {
            bool[,] pattern = GameOfLifeHelper.CreatePattern(new int[] { 6, 6 }, new int[] { 8, 9, 13, 16, 20, 22, 27 });

            Assert.AreEqual(pattern, _generator.NextGeneration(pattern));
        }

        [Test]
        public void TestForStillLifeBoatPattern()
        {
            bool[,] pattern = GameOfLifeHelper.CreatePattern(new int[] { 5, 5 }, new int[] { 6, 7, 11, 13, 17 });

            Assert.AreEqual(pattern, _generator.NextGeneration(pattern));
        }

        [Test]
        public void TestForOscillatorBlinkerPattern()
        {
            bool[,] pattern1 = GameOfLifeHelper.CreatePattern(new int[] { 5, 5 }, new int[] { 7, 12, 17 });
            bool[,] pattern2 = GameOfLifeHelper.CreatePattern(new int[] { 5, 5 }, new int[] { 11, 12, 13 });

            Assert.AreEqual(pattern2, _generator.NextGeneration(pattern1));
            Assert.AreEqual(pattern1, _generator.NextGeneration(pattern2));
        }

        [Test]
        public void TestForOscillatorToadPattern()
        {
            bool[,] pattern1 = GameOfLifeHelper.CreatePattern(new int[] { 6, 6 }, new int[] { 14, 15, 16, 19, 20, 21 });
            bool[,] pattern2 = GameOfLifeHelper.CreatePattern(new int[] { 6, 6 }, new int[] { 9, 13, 16, 19, 22, 26 });

            Assert.AreEqual(pattern2, _generator.NextGeneration(pattern1));
            Assert.AreEqual(pattern1, _generator.NextGeneration(pattern2));
        }

        [Test]
        public void TestForOscillatorBeaconPattern()
        {
            bool[,] pattern1 = GameOfLifeHelper.CreatePattern(new int[] { 6, 6 }, new int[] { 7, 8, 13, 14, 21, 22, 27, 28 });

            bool[,] pattern2 = GameOfLifeHelper.CreatePattern(new int[] { 6, 6 }, new int[] { 7, 8, 13, 22, 27, 28 });

            Assert.AreEqual(pattern2, _generator.NextGeneration(pattern1));
            Assert.AreEqual(pattern1, _generator.NextGeneration(pattern2));
        }

        [Test]
        public void TestForOscillatorPulsarPattern()
        {
            bool[,] pattern1 = GameOfLifeHelper.CreatePattern(new int[] { 17, 17 }, new int[] { 38, 39, 45, 46, 56, 57, 61, 62, 70, 73, 75, 77, 79, 82, 87, 88, 89, 91, 92, 94, 95, 97, 98, 99, 105, 107, 109, 111, 113, 115, 123, 124, 125, 129, 130, 131, 157, 158, 159, 163, 164, 165, 173, 175, 177, 179, 181, 183, 189, 190, 191, 193, 194, 196, 197, 199, 200, 201, 206, 209, 211, 213, 215, 218, 226, 227, 231, 232, 242, 243, 249, 250 });

            bool[,] pattern2 = GameOfLifeHelper.CreatePattern(new int[] { 17, 17 }, new int[] { 38, 39, 40, 44, 45, 46, 70, 75, 77, 82, 87, 92, 94, 99, 104, 109, 111, 116, 123, 124, 125, 129, 130, 131, 157, 158, 159, 163, 164, 165, 172, 177, 179, 184, 189, 194, 196, 201, 206, 211, 213, 218, 242, 243, 244, 248, 249, 250 });

            bool[,] pattern3 = GameOfLifeHelper.CreatePattern(new int[] { 17, 17 }, new int[] { 22, 28, 39, 45, 56, 57, 61, 62, 86, 87, 88, 91, 92, 94, 95, 98, 99, 100, 105, 107, 109, 111, 113, 115, 124, 125, 129, 130, 158, 159, 163, 164, 173, 175, 177, 179, 181, 183, 188, 189, 190, 193, 194, 196, 197, 200, 201, 202, 226, 227, 231, 232, 243, 249, 260, 266 });

            Assert.AreEqual(pattern2, _generator.NextGeneration(pattern1));
            Assert.AreEqual(pattern3, _generator.NextGeneration(pattern2));
            Assert.AreEqual(pattern1, _generator.NextGeneration(pattern3));
        }

        [Test]
        public void TestGridResizeWhenNoLiveCellsOnEdge()
        {
            Assert.IsFalse(_generator.CheckIfNeedsResize(GameOfLifeHelper.CreatePattern(new int[] { 3, 3 }, new int[] { 4 })));
        }

        [Test]
        public void TestGridResizeWhenTwoLiveCellsOnEdge()
        {
            Assert.IsFalse(_generator.CheckIfNeedsResize(GameOfLifeHelper.CreatePattern(new int[] { 3, 3 }, new int[] { 0, 3 })));
        }

        [Test]
        public void TestGridResizedWhenThreeContinuousLiveCellsOnEdge()
        {
            Assert.IsTrue(_generator.CheckIfNeedsResize(GameOfLifeHelper.CreatePattern(new int[] { 4, 4 }, new int[] { 1, 2, 3 })));
        }

        [Test]
        public void TestGridNotResizedWithAllDeadCells()
        {
            Assert.AreEqual(GameOfLifeHelper.CreatePattern(new int[] { 3, 3 }), _generator.ResizeGrid(GameOfLifeHelper.CreatePattern(new int[] { 3, 3 })));
        }

        [Test]
        public void TestGridWillResizedWithAllLiveCellsOnEdge()
        {
            Assert.AreEqual(GameOfLifeHelper.CreatePattern(new int[] { 5, 5 },new int[] {6,7,8}), _generator.ResizeGrid(GameOfLifeHelper.CreatePattern(new int[] { 3, 3 },new int[]{0,1,2})));
        }

        private int GetNumberOfLiveCells(bool[,] cells)
        {
            int count = 0;
            for (int i = 0; i < cells.GetLength(0); i++)
                for (int j = 0; j < cells.GetLength(1); j++)
                    if (cells[i, j]) count++;
            return count;
        }

        [Test]
        public void TestGetNumberOfLiveCellsForAllDeadCells()
        {
            Assert.AreEqual(0, GetNumberOfLiveCells(GameOfLifeHelper.CreatePattern(new int[] { 3, 3 })));
        }

        [Test]
        public void TestGetNumberOfLiveCellsForAllLiveCells()
        {
            Assert.AreEqual(9, GetNumberOfLiveCells(GameOfLifeHelper.CreatePattern(new int[] { 3, 3 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })));
        }

        [Test]
        public void TestForSpaceShipGliderPattern()
        {
            bool[,] pattern = GameOfLifeHelper.CreatePattern(new int[] { 4, 4 }, new int[] { 2, 4, 6, 9, 10 });
            Assert.AreEqual(GetNumberOfLiveCells(pattern),GetNumberOfLiveCells(_generator.NextGeneration(pattern)));
        }

        [Test]
        public void TestForLightWeightSpaceship()
        {
            bool[,] pattern = GameOfLifeHelper.CreatePattern(new int[] { 6, 6 }, new int[] { 0, 3, 10, 12, 16, 19, 20, 21, 22 });
            Assert.AreEqual(GetNumberOfLiveCells(pattern),GetNumberOfLiveCells(_generator.NextGeneration(_generator.NextGeneration(pattern))));
        }

        [Test]
        public void TestForLightWeightSpaceshipAfterFourGenerations()
        {
            bool[,] pattern = GameOfLifeHelper.CreatePattern(new int[] { 6, 6 }, new int[] { 0, 3, 10, 12, 16, 19, 20, 21, 22 });
            bool[,] pattern1 = GameOfLifeHelper.CreatePattern(new int[] { 6, 6 }, new int[] { 0, 3, 10, 12, 16, 19, 20, 21, 22 });

            for (int i = 0; i < 4; i++)
                pattern1 = _generator.NextGeneration(pattern1);

            Assert.AreEqual(GetNumberOfLiveCells(pattern), GetNumberOfLiveCells(pattern1));
        }
    }
}
