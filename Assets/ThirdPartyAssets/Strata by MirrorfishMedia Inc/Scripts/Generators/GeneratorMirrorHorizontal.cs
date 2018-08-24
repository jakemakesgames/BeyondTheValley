using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Strata;

[CreateAssetMenu(menuName = "Strata/Generators/Mirror Horizontal")]

public class GeneratorMirrorHorizontal : Generator
{

    public override bool Generate(BoardGenerator boardGenerator)
    {
        MirrorGridHorizontal(boardGenerator);
        return true;
    }

    private void MirrorGridHorizontal(BoardGenerator boardGenerator)
    {
        for (int i = 0; i < boardGenerator.profile.boardHorizontalSize; i++)
        {
            for (int j = 0; j < boardGenerator.profile.boardVerticalSize; j++)
            {
                char charToRewrite = boardGenerator.boardGridAsCharacters[i, j];
                boardGenerator.WriteToBoardGrid(boardGenerator.profile.boardHorizontalSize - i, j, charToRewrite, true, false);
            }
        }
    }
}
