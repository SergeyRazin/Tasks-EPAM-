using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.MyExceptions
{
    /// <summary>
    /// выбрасывается когда месторождение с таким именем уже существует
    /// </summary>
    [Serializable]
    public class MyOverlapNameException : Exception
    {
        //КОНСТРУКТОРЫ полностью наследуются от базового класса

        #region конструкторы

        public MyOverlapNameException()
            : base()
        {
        }

        public MyOverlapNameException(String str)
            : base(str)
        {
        }

        public MyOverlapNameException(String str, Exception inner)
            : base(str, inner)
        {
        }

        protected MyOverlapNameException(SerializationInfo si, StreamingContext sc)
            : base(si, sc)
        {
        }

        #endregion

        //переопределим ToString()
        public override string ToString()
        {
            return Message;
        }
    }

    /// <summary>
    /// выбрасывается когда месторождение с таким именем не найдено
    /// </summary>
    [Serializable]
    public class MyOilfieldNameNotFoundException : Exception
    {
        //КОНСТРУКТОРЫ полностью наследуются от базового класса

        #region конструкторы

        public MyOilfieldNameNotFoundException()
            : base()
        {
        }

        public MyOilfieldNameNotFoundException(String str)
            : base(str)
        {
        }

        public MyOilfieldNameNotFoundException(String str, Exception inner)
            : base(str, inner)
        {
        }

        protected MyOilfieldNameNotFoundException(SerializationInfo si, StreamingContext sc)
            : base(si, sc)
        {
        }

        #endregion

        //переопределим ToString()
        public override string ToString()
        {
            return Message;
        }
    }

    /// <summary>
    /// выбрасывается когда месторождение с таким именем не найдено
    /// </summary>
    [Serializable]
    public class MyWellNotFoundException : Exception
    {
        //КОНСТРУКТОРЫ полностью наследуются от базового класса

        #region конструкторы

        public MyWellNotFoundException()
            : base()
        {
        }

        public MyWellNotFoundException(String str)
            : base(str)
        {
        }

        public MyWellNotFoundException(String str, Exception inner)
            : base(str, inner)
        {
        }

        protected MyWellNotFoundException(SerializationInfo si, StreamingContext sc)
            : base(si, sc)
        {
        }

        #endregion

        //переопределим ToString()
        public override string ToString()
        {
            return Message;
        }
    }

    /// <summary>
    /// выбрасывается когда атрибута AttributeTable нет.
    /// </summary>
    [Serializable]
    public class MyTableAttributeNotFound : Exception
    {
        //КОНСТРУКТОРЫ полностью наследуются от базового класса

        #region конструкторы

        public MyTableAttributeNotFound()
            : base()
        {
        }

        public MyTableAttributeNotFound(String str0)
            : base(str0)
        {
        }

        public MyTableAttributeNotFound(String str0, Exception inner0)
            : base(str0, inner0)
        {
        }

        protected MyTableAttributeNotFound(SerializationInfo si0, StreamingContext sc0)
            : base(si0, sc0)
        {
        }

        #endregion

        //переопределим ToString()
        public override string ToString()
        {
            return Message;
        }
    }

    
    
}
