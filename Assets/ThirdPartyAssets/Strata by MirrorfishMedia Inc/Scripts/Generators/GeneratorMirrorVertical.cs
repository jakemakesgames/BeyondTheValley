using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strata
{
    [CreateAssetMenu(menuName = "Strata/Generators/Mirror Vertical")]

    public class GeneratorMirrorVertical : Generator
    {

        public override bool Generate(BoardGenerator boardGenerator)
        {
            MirrorGridVertical(boardGenerator);
            return true;
        }

        private void MirrorGridVertical(BoardGenerator boardGenerator)
        {

            for (int i = 0; i < boardGenerator.profile.boardHorizontalSize; i++)
            {
                for (int j = 0; j < boardGenerator.profile.boardVerticalSize; j++)
                {
                    char charToRewrite = boardGenerator.boardGridAsCharacters[i, j];
                    boardGenerator.WriteToBoardGrid(i, boardGenerator.profile.boardVerticalSize - j, charToRewrite, true, false);
                }
            }
        }
    }
}

