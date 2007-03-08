using System;

namespace NUnit.Framework.Constraints
{
	// TODO Needs tests
	/// <summary>
	/// ContainsConstraint tests a whether a string contains a substring
	/// or a collection contains an object. It postpones the decision of
	/// which test to use until the type of the actual argument is known.
	/// This allows testing whether a string is contained in a collection
	/// or as a substring of another string using the same syntax.
	/// </summary>
	public class ContainsConstraint : Constraint
	{
		object expected;
		Constraint realConstraint;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ContainsConstraint"/> class.
        /// </summary>
        /// <param name="expected">The expected.</param>
		public ContainsConstraint( object expected )
		{
			this.expected = expected;
		}

        /// <summary>
        /// Test whether the constraint is satisfied by a given value
        /// </summary>
        /// <param name="actual">The value to be tested</param>
        /// <returns>True for success, false for failure</returns>
		public override bool Matches(object actual)
		{
			this.actual = actual;
			if ( actual is string )
				this.realConstraint = new SubstringConstraint( (string)expected );
			else
				this.realConstraint = new CollectionContainsConstraint( expected );

			if ( this.caseInsensitive )
				this.realConstraint = this.realConstraint.IgnoreCase;

			return this.realConstraint.Matches( actual );
		}

        /// <summary>
        /// Write the constraint description to a MessageWriter
        /// </summary>
        /// <param name="writer">The writer on which the description is displayed</param>
		public override void WriteDescriptionTo(MessageWriter writer)
		{
			this.realConstraint.WriteDescriptionTo(writer);
		}
	}
}