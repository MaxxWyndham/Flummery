using System;
using System.Collections.Generic;
using ToxicRagers.Helpers;

namespace Flummery
{
    public class ModelBone
    {
        List<ModelBone> Children;
        int Index;
        string Name;
        ModelBone Parent;
        Matrix3D Transform;
    }
}
