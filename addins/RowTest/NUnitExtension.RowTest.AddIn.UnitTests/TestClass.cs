// *********************************************************************
// Copyright 2007, Andreas Schlapsi
// This is free software licensed under the MIT license. 
// *********************************************************************
using System;
using NUnit.Framework;

namespace NUnitExtension.RowTest.AddIn.UnitTests
{
	public class TestClass
	{
		private object[] _arguments;
		
		public TestClass()
		{
		}
		
		public object[] Arguments
		{
			get { return _arguments; }
		}

		public void MethodWithoutRowTestAttribute()
		{
			Assert.Fail("Should not be called.");
		}

		[RowTest]
		public void MethodWithRowTestAttribute()
		{
		}

		[Row(42, 21)]
		public void MethodWithRowAttribute(int a, int b)
		{
			Assert.Fail("Should not be called.");
		}

		[RowTest]
		[Row(4, 5)]
		[Row(5, 6)]
		public void RowTestMethodWith2Rows(int a, int b)
		{
			if (_arguments != null)
				throw new InvalidOperationException("Arguments are already set.");
			
			_arguments = new object[] { a, b };
		}

		[RowTest]
		[Row(4, 5, ExpectedException=typeof(InvalidOperationException))]
		public void RowTestMethodWithExpectedException(int a, int b)
		{
			if (_arguments != null)
				throw new InvalidOperationException("Arguments are already set.");
			
			_arguments = new object[] { a, b };
		}

		[RowTest]
		[Row(4, 5, ExpectedException=typeof(InvalidOperationException), ExceptionMessage="Expected Exception Message.")]
		public void RowTestMethodWithExpectedExceptionAndExceptionMessage(int a, int b)
		{
			if (_arguments != null)
				throw new InvalidOperationException("Arguments are already set.");
			
			_arguments = new object[] { a, b };
		}

		[RowTest]
		[Row(4, 5, TestName="UnitTest")]
		public void RowTestMethodWithTestName(int a, int b)
		{
			if (_arguments != null)
				throw new InvalidOperationException("Arguments are already set.");
			
			_arguments = new object[] { a, b };
		}
		
		[RowTest]
		[Row(null)]
		public void RowTestMethodWithNullArgument(object a)
		{
			if (_arguments != null)
				throw new InvalidOperationException("Arguments are already set.");
			
			_arguments = new object[] { a };
		}
		
#if !FX1_1 && !NET_1_1
		[RowTest]
		[Row(9, null)]
		public void RowTestMethodWithNormalAndNullArgument(int a, object b)
		{
			if (_arguments != null)
				throw new InvalidOperationException("Arguments are already set.");
			
			_arguments = new object[] { a, b };
		}
#endif

		[RowTest]
		[Category("Category")]
		[Row(5, 6)]
		public void RowTestMethodWithCategory(int a, int b)
		{
			if (_arguments != null)
				throw new InvalidOperationException("Arguments are already set.");
			
			_arguments = new object[] { a, b };
		}
		
		[RowTest]
		[Row(SpecialValue.Null)]
		public void RowTestMethodWithSpecialValue(object a)
		{
			if (_arguments != null)
				throw new InvalidOperationException("Arguments are already set.");
			
			_arguments = new object[] { a };
		}
	}
}
