using System;
using System.Collections.Generic;
using System.Linq;

namespace Flummery.Core
{
    public class EntityCollection : List<IEntity>
    {
        public void Add(IEntity entity, bool dedupe)
        {
            if (dedupe) { this.RemoveType(entity.GetType()); }

            Add(entity);
        }
    }

    public static class EntityCollectionExtensions
    {
        public static void RemoveType(this EntityCollection entities, Type type)
        {
            List<IEntity> toRemove = entities.Where(e => e.GetType() == type).ToList();

            foreach (IEntity item in toRemove) { entities.Remove(item); }
        }

        public static void Remove<T>(this EntityCollection entities)
        {
            entities.RemoveType(typeof(T));
        }
    }
}
