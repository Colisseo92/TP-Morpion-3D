using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public GameObject tokenPrefab;
    public Color color;

    public List<Vector3Int> plays;

    private bool isSimilar(Vector3Int vec1, Vector3Int vec2)
    {
        int similar_coord = 0;
        if (vec1.x.Equals(vec2.x))
        {
            similar_coord += 1;
        }
        if (vec1.y.Equals(vec2.y))
        {
            similar_coord +=  1;
        }
        if (vec1.z.Equals(vec2.z))
        {
            similar_coord += 1;
        }
        return similar_coord.Equals(2);
    }

    private bool isDiagonal(Vector3Int vec1)
    {
        int zero_count = 0;
        if (vec1.x.Equals(0))
        {
            zero_count += 1;
        }
        if (vec1.y.Equals(0))
        {
            zero_count += 1;
        }
        if (vec1.z.Equals(0))
        {
            zero_count += 1;
        }
        return zero_count == 2;
    }

    private bool isCorner(Vector3Int vec1)
    {
        int count_one = 0;
        if (Mathf.Abs(vec1.x).Equals(1))
        {
            count_one += 1;
        }
        if (Mathf.Abs(vec1.y).Equals(1))
        {
            count_one += 1;
        }
        if (Mathf.Abs(vec1.z).Equals(1))
        {
            count_one += 1;
        }
        return count_one == 3;
    }

    private Vector3Int getDiagonalVector(Vector3Int vec1) {
        return new Vector3Int(-vec1.x, -vec1.y, -vec1.z);
    }

    public bool hasWon()
    {
        bool result = false;
        foreach(Vector3Int vec1 in plays)
        {
            if (isDiagonal(vec1))
            {
                //Pour les faces avant et arrière
                Vector3Int diag1 = new Vector3Int(vec1.x - 1, vec1.y + 1, vec1.z);
                Vector3Int diag2 = new Vector3Int(vec1.x - 1, vec1.y - 1, vec1.z);
                Vector3Int diag3 = new Vector3Int(vec1.x + 1, vec1.y + 1, vec1.z);
                Vector3Int diag4 = new Vector3Int(vec1.x + 1, vec1.y - 1, vec1.z);
                if(plays.Contains(diag1) && plays.Contains(diag4))
                {
                    return true;
                }
                if(plays.Contains(diag2) && plays.Contains(diag3))
                {
                    return true;
                }
                //Pour les faces sur le côté
                Vector3Int diag5 = new Vector3Int(vec1.x , vec1.y + 1, vec1.z+1);
                Vector3Int diag6 = new Vector3Int(vec1.x , vec1.y - 1, vec1.z+1);
                Vector3Int diag7 = new Vector3Int(vec1.x , vec1.y + 1, vec1.z-1);
                Vector3Int diag8 = new Vector3Int(vec1.x , vec1.y - 1, vec1.z-1);
                if (plays.Contains(diag5) && plays.Contains(diag8))
                {
                    return true;
                }
                if (plays.Contains(diag7) && plays.Contains(diag6))
                {
                    return true;
                }
                //Pour les faces du dessus
                Vector3Int diag9 = new Vector3Int(vec1.x-1, vec1.y, vec1.z + 1);
                Vector3Int diag10 = new Vector3Int(vec1.x-1, vec1.y, vec1.z + 1);
                Vector3Int diag11 = new Vector3Int(vec1.x+1, vec1.y, vec1.z - 1);
                Vector3Int diag12 = new Vector3Int(vec1.x+1, vec1.y, vec1.z - 1);
                if (plays.Contains(diag9) && plays.Contains(diag12))
                {
                    return true;
                }
                if (plays.Contains(diag10) && plays.Contains(diag11))
                {
                    return true;
                }
            }
            foreach (Vector3Int vec2 in plays)
            {
                //Test pour les diagonals sur les différents étages
                if(vec1.Equals(new Vector3Int(0, 0, 0)))
                {
                    if (isCorner(vec2))
                    {
                        if (plays.Contains(getDiagonalVector(vec2)))
                        {
                            return true;
                        }
                    }
                }
                foreach (Vector3Int vec3 in plays)
                {
                    if (!vec1.Equals(vec2) && !vec1.Equals(vec3) && !vec2.Equals(vec3))
                    {
                        if(isSimilar(vec1,vec2) && isSimilar(vec1,vec3) && isSimilar(vec2, vec3))
                        {
                            return true;
                        }
                    }
                }
            }
        }

        return result;
    }
}
