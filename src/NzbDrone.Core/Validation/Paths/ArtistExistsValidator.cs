﻿using FluentValidation.Validators;
using NzbDrone.Core.Books;

namespace NzbDrone.Core.Validation.Paths
{
    public class ArtistExistsValidator : PropertyValidator
    {
        private readonly IAuthorService _authorService;

        public ArtistExistsValidator(IAuthorService authorService)
            : base("This author has already been added.")
        {
            _authorService = authorService;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null)
            {
                return true;
            }

            return !_authorService.GetAllAuthors().Exists(s => s.Metadata.Value.ForeignAuthorId == context.PropertyValue.ToString());
        }
    }
}
