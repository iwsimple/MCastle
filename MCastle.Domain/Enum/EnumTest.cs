using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCastle.Domain
{
    public class AstickCollection : IEnumerable
    {
        //public IEnumerator<Astick> GetEnumerator()
        //{
        //    return new AstickEnumerator();
        //}

        public AstickCollection(Astick[] _array)
        {
            astickArray = _array;
            this.count = _array.Count();
        }

        public Astick[] astickArray;

        public int count;

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Astick this[int index]
        {
            get { return astickArray[index]; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new AstickEnumerator(this);
        }

        public class AstickEnumerator : IEnumerator
        {
            public int index = -1;
            public AstickCollection collection;

            internal AstickEnumerator(AstickCollection _collection)
            {
                collection = _collection;
            }

            public object Current
            {
                get { return collection[index]; }
            }

            public bool MoveNext()
            {
                if (index < collection.count - 1)
                {
                    index++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }

    public class Astick
    {
        public Astick(string name)
        {
            this.name = name;
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }
    }
}
