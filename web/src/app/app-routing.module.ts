import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { HomeComponent } from './home/home/home.component';
import { DashboardComponent } from './home/dashboard/dashboard.component';
import { InventoryComponent } from './categories/inventory/inventory.component';
import { CustomerComponent } from './customer/customer/customer.component';
import { PowerDetailsComponent } from './customer/power-details/power-details.component';
import { ContactLensComponent } from './customer/contact-lens/contact-lens.component';
import { JobOrderComponent } from './customer/job-order/job-order.component';
import { DayCashComponent } from './pay/day-cash/day-cash.component';
import { PayRemainingComponent } from './pay/pay-remaining/pay-remaining.component';
import { ClientBalanceComponent } from './pay/client-balance/client-balance.component';
import { WorkshopManagerComponent } from './management/workshop-manager/workshop-manager.component';
import { DamagedGoodComponent } from './management/damaged-good/damaged-good.component';
import { ExchangeSaleReturnComponent } from './management/exchange-sale-return/exchange-sale-return.component';
import { StockInComponent } from './stock/stock-in/stock-in.component';
import { StockOutComponent } from './stock/stock-out/stock-out.component';
import { SunglassComponent } from './sales/sunglass/sunglass.component';
import { SolutionComponent } from './sales/solution/solution.component';
import { AuthGuard } from '../auth.guard';
import { SalesPersonAccountDetailsComponent } from './sales/sales-person-account-details/sales-person-account-details.component';
import { SendSmsComponent } from './settings/send.sms/send.sms.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'home', component: HomeComponent, canActivate: [AuthGuard],
    children: [
      { path: '', component: DashboardComponent }, // Default route for HomeComponent
      { path: 'inventory', component: InventoryComponent },
      { path: 'customer', component: CustomerComponent },
      { path: 'power-details', component: PowerDetailsComponent },
      { path: 'contact-lens', component: ContactLensComponent },
      { path: 'job-order', component: JobOrderComponent },
      { path: 'day-cash', component: DayCashComponent },
      { path: 'pay-remaining', component: PayRemainingComponent },
      { path: 'client-balance', component: ClientBalanceComponent },
      { path: 'workshop-manager', component: WorkshopManagerComponent },
      { path: 'damaged-good', component: DamagedGoodComponent },
      { path: 'exchange-sale-return', component: ExchangeSaleReturnComponent },
      { path: 'stock-in', component: StockInComponent },
      { path: 'stock-out', component: StockOutComponent },
      { path: 'sunglass', component: SunglassComponent },
      { path: 'solution', component: SolutionComponent },
      { path: 'sales-person-account-details', component: SalesPersonAccountDetailsComponent },
      { path: 'send.sms', component: SendSmsComponent },
    ]
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },  // Default route redirects to login page
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
