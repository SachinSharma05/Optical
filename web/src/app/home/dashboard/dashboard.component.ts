import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

export class DashboardComponent {
  menuItems = [
    { label: 'Inventory', icon: '/assets/SubCategory.png', link: 'inventory' },
    { label: 'Create Customer', icon: '/assets/images51.jpg', link: 'customer' },
    { label: 'Power Details', icon: '/assets/Lens.png', link: 'power-details' },
    { label: 'Contact Lens Sale', icon: '/assets/invoice.png', link: 'contact-lens' },
    { label: 'Create Job Order', icon: '/assets/Make-Invoice.png', link: 'job-order' },
    { label: 'Day Cash', icon: '/assets/payment-icon.png', link: 'day-cash' },
    { label: 'Pay Remaining', icon: '/assets/PayCL.jpg', link: 'pay-remaining' },
    { label: 'Clients Balance', icon: '/assets/bi-0035-48.gif', link: 'client-balance' },
    { label: 'Workshop Manager', icon: '/assets/Utilities-icon.png', link: 'workshop-manager' },
    { label: 'Damaged Goods', icon: '/assets/2489-damaged-_xlarge.jpg', link: 'damaged-good' },
    { label: 'Exchange / Return', icon: '/assets/Exchange.png', link: 'exchange-sale-return' },
    { label: 'Stock In', icon: '/assets/add stock.png', link: 'stock-in' },
    { label: 'Stock Out', icon: '/assets/Product.png', link: 'stock-out' },
    { label: 'Sunglass', icon: '/assets/sunglass.png', link: 'sunglass' },
    { label: 'Solution', icon: '/assets/Category.ico', link: 'solution' },
  ];
  cols: number | undefined;

  constructor(private router: Router) {}

  navigateTo(link: string) {
    this.router.navigate([`/home/${link}`]);
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: { target: { innerWidth: any; }; }) {
    const width = event.target.innerWidth;
    if (width <= 600) {
      this.cols = 2;
    } else if (width <= 960) {
      this.cols = 3;
    } else {
      this.cols = 4;
    }
}

}
