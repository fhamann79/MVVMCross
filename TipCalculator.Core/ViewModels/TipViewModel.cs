using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.Core.Services;

namespace TipCalculator.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculationService;
        private decimal _subtotal;
        private int _generosity;
        private decimal _tip;

        public TipViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public decimal Subtotal 
        { 
            get => _subtotal; 
            set
            {
                _subtotal = value;
                RaisePropertyChanged(() => Subtotal);
                Recalculate();
            }
        }
        public int Generosity 
        { 
            get => _generosity; 
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);
                Recalculate();
            }
        }



        public decimal Tip 
        { 
            get => _tip; 
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            } 
        }

        public async override Task Initialize()
        {
            await base.Initialize();

            Subtotal = 100;
            Generosity = 10;
            Recalculate();

        }

        private void Recalculate()
        {
            Tip = _calculationService.TipAmount(Subtotal, Generosity);
        }
    }
}
