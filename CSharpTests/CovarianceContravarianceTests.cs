using CSharpGeneral.CovarianceContravariance;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharpTests
{
    public class CovarianceContravarianceTests
    {
        [Fact]
        public void CovarianceAssignment_Test()
        {
            Play.CovarianceAssignment();
        }

        [Fact]
        public void ContravarianceAssignment_Test()
        {
            Play.ContravarianceAssignment();
        }

        [Fact]
        public void ContraVarianceInInterfaces_Test()
        {
            Play.ContraVarianceInInterfaces();
        }
    }
}
