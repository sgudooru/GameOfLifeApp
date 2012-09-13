using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GameOfLifeLib
{
    public class GameOfLifeHelperTest
    {
        [Test]
        public void TestCreatePatternAllDeadCell()
        {
            bool[,] pattern = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };

            Assert.AreEqual(pattern, GameOfLifeHelper.CreatePattern(new int[] { 3, 3 }));
        }

        [Test]
        public void TestCreatePatternAllLiveCells()
        {
            bool[,] pattern = new bool[3, 3] { { true, true, true }, { true, true, true }, { true, true, true } };

            Assert.AreEqual(pattern, GameOfLifeHelper.CreatePattern(new int[] { 3, 3 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }));
        }

        [Test]
        public void TestCreatePatternWithLiveAndDeadCells()
        {
            bool[,] pattern = new bool[5, 5] { { false, false, false, false, false }, { false, true, true, false, false }, { false, true, false, true, false }, { false, false, true, false, false }, { false, false, false, false, false } };

            Assert.AreEqual(pattern, GameOfLifeHelper.CreatePattern(new int[] { 5, 5 }, new int[] { 6, 7, 11, 13, 17 }));
        }

        [Test]
        public void TestCreatePatternOutOfBoundCell()
        {
            bool[,] pattern = new bool[3, 3] { { false, false, false }, { true, true, true }, { false, false, false } };

            Assert.AreEqual(pattern, GameOfLifeHelper.CreatePattern(new int[] { 3, 3 }, new int[] { 3, 4, 10, 5 }));
        }

        [Test]
        public void TestCreatePatternInvalidSizeWithOneElementForSize()
        {
            Assert.AreEqual(null, GameOfLifeHelper.CreatePattern(new int[] { 2 }, new int[] { 3, 4 }));
        }

        [Test]
        public void TestCreatePatternInvalidSizeWithThreeElementsForSize()
        {
            Assert.AreEqual(new bool[2, 2] { { true, false }, { false, true } }, GameOfLifeHelper.CreatePattern(new int[] { 2, 2, 3 }, new int[] { 0, 3 }));
        }

        [Test]
        public void TestCreatePatternWithOutOfBoundLiveCellPositions()
        {
            Assert.AreEqual(new bool[2, 2] { { true, false }, { true, false } }, GameOfLifeHelper.CreatePattern(new int[] { 2, 2, 3 }, new int[] { -1, 0, 2, 4, 7 }));
        }

        [Test]
        public void TestCreatePatternWithNullSize()
        {
            try
            {
                GameOfLifeHelper.CreatePattern(null);
                Assert.Fail("Expects a NullReferenceException here.");
            }
            catch (NullReferenceException)
            {
            }
        }

        [Test]
        public void TestCreatePatternWithPositionsAsNull()
        {
            Assert.AreEqual(new bool[2, 3], GameOfLifeHelper.CreatePattern(new int[]{2,3},null));
        }
    }
}
