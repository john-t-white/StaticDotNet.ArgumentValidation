#if NET8_0_OR_GREATER

using System.Text;

namespace StaticDotNet.ArgumentValidation.Resources;

internal static class ExceptionMessagesCompositeFormats {

	internal static readonly CompositeFormat STRING_LENGTH_BELOW_MIN_LENGTH = CompositeFormat.Parse( ExceptionMessages.STRING_LENGTH_BELOW_MIN_LENGTH );
	internal static readonly CompositeFormat STRING_LENGTH_EXCEEDS_MAX_LENGTH = CompositeFormat.Parse( ExceptionMessages.STRING_LENGTH_EXCEEDS_MAX_LENGTH );
	internal static readonly CompositeFormat STRING_LENGTH_MUST_BE_BETWEEN = CompositeFormat.Parse( ExceptionMessages.STRING_LENGTH_MUST_BE_BETWEEN );
	internal static readonly CompositeFormat STRING_LENGTH_MUST_BE_EQUAL_TO = CompositeFormat.Parse( ExceptionMessages.STRING_LENGTH_MUST_BE_EQUAL_TO );
	internal static readonly CompositeFormat STRING_MUST_BE_ASCII_DIGITS = CompositeFormat.Parse( ExceptionMessages.STRING_MUST_BE_ASCII_DIGITS );
	internal static readonly CompositeFormat STRING_MUST_BE_ASCII_LETTERS = CompositeFormat.Parse( ExceptionMessages.STRING_MUST_BE_ASCII_LETTERS );
	internal static readonly CompositeFormat STRING_MUST_BE_ASCII_LETTERS_OR_DIGITS = CompositeFormat.Parse( ExceptionMessages.STRING_MUST_BE_ASCII_LETTERS_OR_DIGITS );
	internal static readonly CompositeFormat STRING_MUST_BE_LOWER_ASCII_LETTERS = CompositeFormat.Parse( ExceptionMessages.STRING_MUST_BE_LOWER_ASCII_LETTERS );
	internal static readonly CompositeFormat STRING_MUST_BE_LOWER_ASCII_LETTERS_OR_DIGITS = CompositeFormat.Parse( ExceptionMessages.STRING_MUST_BE_LOWER_ASCII_LETTERS_OR_DIGITS );
	internal static readonly CompositeFormat STRING_MUST_BE_UPPER_ASCII_LETTERS = CompositeFormat.Parse( ExceptionMessages.STRING_MUST_BE_UPPER_ASCII_LETTERS );
	internal static readonly CompositeFormat STRING_MUST_BE_UPPER_ASCII_LETTERS_OR_DIGITS = CompositeFormat.Parse( ExceptionMessages.STRING_MUST_BE_UPPER_ASCII_LETTERS_OR_DIGITS );
	internal static readonly CompositeFormat STRING_MUST_CONTAIN = CompositeFormat.Parse( ExceptionMessages.STRING_MUST_CONTAIN );
	internal static readonly CompositeFormat STRING_MUST_END_WITH = CompositeFormat.Parse( ExceptionMessages.STRING_MUST_END_WITH );
	internal static readonly CompositeFormat STRING_MUST_START_WITH = CompositeFormat.Parse( ExceptionMessages.STRING_MUST_START_WITH );
	internal static readonly CompositeFormat TYPE_MUST_BE_ASSIGNABLE_TO = CompositeFormat.Parse( ExceptionMessages.TYPE_MUST_BE_ASSIGNABLE_TO );
	internal static readonly CompositeFormat VALUE_LENGTH_BELOW_MIN_LENGTH = CompositeFormat.Parse( ExceptionMessages.VALUE_LENGTH_BELOW_MIN_LENGTH );
	internal static readonly CompositeFormat VALUE_LENGTH_EXCEEDS_MAX_LENGTH = CompositeFormat.Parse( ExceptionMessages.VALUE_LENGTH_EXCEEDS_MAX_LENGTH );
	internal static readonly CompositeFormat VALUE_LENGTH_MUST_BE_BETWEEN = CompositeFormat.Parse( ExceptionMessages.VALUE_LENGTH_MUST_BE_BETWEEN );
	internal static readonly CompositeFormat VALUE_LENGTH_MUST_BE_EQUAL_TO = CompositeFormat.Parse( ExceptionMessages.VALUE_LENGTH_MUST_BE_EQUAL_TO );
	internal static readonly CompositeFormat VALUE_MUST_BE_ABSOLUTE_URI = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_ABSOLUTE_URI );
	internal static readonly CompositeFormat VALUE_MUST_BE_ABSOLUTE_WITH_SCHEME = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_ABSOLUTE_WITH_SCHEME );
	internal static readonly CompositeFormat VALUE_MUST_BE_ASCII_DIGIT = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_ASCII_DIGIT );
	internal static readonly CompositeFormat VALUE_MUST_BE_ASCII_LETTER = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_ASCII_LETTER );
	internal static readonly CompositeFormat VALUE_MUST_BE_ASCII_LETTER_OR_DIGIT = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_ASCII_LETTER_OR_DIGIT );
	internal static readonly CompositeFormat VALUE_MUST_BE_ASSIGNABLE_TO = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_ASSIGNABLE_TO );
	internal static readonly CompositeFormat VALUE_MUST_BE_BETWEEN = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_BETWEEN );
	internal static readonly CompositeFormat VALUE_MUST_BE_DIGIT = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_DIGIT );
	internal static readonly CompositeFormat VALUE_MUST_BE_EQUAL_TO = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_EQUAL_TO );
	internal static readonly CompositeFormat VALUE_MUST_BE_GREATER_THAN = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_GREATER_THAN );
	internal static readonly CompositeFormat VALUE_MUST_BE_GREATER_THAN_OR_EQUAL_TO = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_GREATER_THAN_OR_EQUAL_TO );
	internal static readonly CompositeFormat VALUE_MUST_BE_LESS_THAN = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_LESS_THAN );
	internal static readonly CompositeFormat VALUE_MUST_BE_LESS_THAN_OR_EQUAL_TO = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_LESS_THAN_OR_EQUAL_TO );
	internal static readonly CompositeFormat VALUE_MUST_BE_LETTER = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_LETTER );
	internal static readonly CompositeFormat VALUE_MUST_BE_LETTER_OR_DIGIT = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_LETTER_OR_DIGIT );
	internal static readonly CompositeFormat VALUE_MUST_BE_LOWER = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_LOWER );
	internal static readonly CompositeFormat VALUE_MUST_BE_LOWER_ASCII_LETTER = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_LOWER_ASCII_LETTER );
	internal static readonly CompositeFormat VALUE_MUST_BE_LOWER_ASCII_LETTER_OR_DIGIT = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_LOWER_ASCII_LETTER_OR_DIGIT );
	internal static readonly CompositeFormat VALUE_MUST_BE_NUMBER = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_NUMBER );
	internal static readonly CompositeFormat VALUE_MUST_BE_PARSABLE_TO = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_PARSABLE_TO );
	internal static readonly CompositeFormat VALUE_MUST_BE_RELATIVE = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_RELATIVE );
	internal static readonly CompositeFormat VALUE_MUST_BE_UPPER = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_UPPER );
	internal static readonly CompositeFormat VALUE_MUST_BE_UPPER_ASCII_LETTER = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_UPPER_ASCII_LETTER );
	internal static readonly CompositeFormat VALUE_MUST_BE_UPPER_ASCII_LETTER_OR_DIGIT = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_BE_UPPER_ASCII_LETTER_OR_DIGIT );
	internal static readonly CompositeFormat VALUE_MUST_CONTAIN = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_CONTAIN );
	internal static readonly CompositeFormat VALUE_MUST_END_WITH = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_END_WITH );
	internal static readonly CompositeFormat VALUE_MUST_HAVE_SCALE_EQUAL_TO = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_HAVE_SCALE_EQUAL_TO );
	internal static readonly CompositeFormat VALUE_MUST_HAVE_SCALE_LESS_THAN_OR_EQUAL_TO = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_HAVE_SCALE_LESS_THAN_OR_EQUAL_TO );
	internal static readonly CompositeFormat VALUE_MUST_MATCH_REGEX = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_MATCH_REGEX );
	internal static readonly CompositeFormat VALUE_MUST_START_WITH = CompositeFormat.Parse( ExceptionMessages.VALUE_MUST_START_WITH );
}

#endif
