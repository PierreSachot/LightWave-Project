using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Audio_Spectrum_Analyzer
{
    /// <summary>
    /// Cette interface est implémentée par l'ensemble des effets proposés dans cette application
    /// </summary>
    public interface IEffect
    {
        /// <summary>
        /// Cette procédure permet de générer l'effet sur l'objet souhaité
        /// </summary>
        /// <param name="size">Taille de l'effet</param>
        void GenerateEffect(int size);
    }
}
