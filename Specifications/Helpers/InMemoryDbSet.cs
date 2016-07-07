using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Specifications
{
    public class InMemoryDbSet<T> : IDbSet<T> where T : class
    {
        readonly List<T> data;

        public InMemoryDbSet()
        {
            data = new List<T>();
        }

        public InMemoryDbSet(IEnumerable<T> predefinedValues)
        {
            data = predefinedValues.ToList();
        }

        public T Add(T entity)
        {
            data.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            data.Add(entity);
            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public virtual T Find(params object[] keyValues)
        {
            var query = data.AsQueryable<T>();
            var property = typeof(T).GetProperty("Id");

            if (property != null)
            {
                foreach (var keyValue in keyValues)
                {
                    query = query.Where(GetExpression("Id", keyValue));
                }
            }

            return query.FirstOrDefault();

        }

        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get { return new System.Collections.ObjectModel.ObservableCollection<T>(data); }
        }

        public T Remove(T entity)
        {
            data.Remove(entity);
            return entity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public Type ElementType
        {
            get { return data.AsQueryable().ElementType; }
        }

        public Expression Expression
        {
            get { return data.AsQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return data.AsQueryable().Provider; }
        }

        public void AddObject(T entity)
        {
            data.Add(entity);
        }

        /// <summary>
        /// Returns expression to use in expression trees, like where statements. For example query.Where(GetExpression("IsDeleted", typeof(boolean), false));
        /// </summary>
        /// <param name="propertyName">The name of the property. Either boolean or a nulleable typ</param>
        private Expression<Func<T, bool>> GetExpression(string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(T));
            var actualValueExpression = Expression.Property(param, propertyName);

            var lambda = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(actualValueExpression,
                    Expression.Constant(value)),
                param);

            return lambda;
        }
    }
}