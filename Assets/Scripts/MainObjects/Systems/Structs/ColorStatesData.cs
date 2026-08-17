using UnityEngine;

public struct ColorStatesData
{
    private Color[] m_colorsStates;
    public readonly Color[] P_ColorsStates => m_colorsStates;

    public ColorStatesData(Color color, int health, float darken)
    {
        float brighten = 1;
        
        m_colorsStates = new Color[health];

        for (int i = 0; i < health; i++)
        {
            m_colorsStates[i] = color * brighten;
            brighten -= darken;
        }
    }
}