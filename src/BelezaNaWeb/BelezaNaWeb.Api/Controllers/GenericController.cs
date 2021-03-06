﻿using System;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BelezaNaWeb.Api.Controllers
{
    public class GenericController : ControllerBase
    {
        #region Protected Read-Only Fields

        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;
        protected readonly IMediator _mediator;

        #endregion

        #region Constructors

        public GenericController(ILogger logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        #endregion
    }
}
