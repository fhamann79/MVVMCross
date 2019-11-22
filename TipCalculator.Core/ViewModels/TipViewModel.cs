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

        public decimal SubTotal 
        { 
            get => _subtotal; 
            set
            {
                _subtotal = value;
                RaisePropertyChanged(() => SubTotal);
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
            set => SetProperty(ref _tip, value);
        }

        public async override Task Initialize()
        {
            await base.Initialize();

            SubTotal = 100;
            Generosity = 10;
            Recalculate();

        }

        private void Recalculate()
        {
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }
    }
}
