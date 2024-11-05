import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';      // Add MatTableModule
import { MatDialogModule } from '@angular/material/dialog';    // Add MatDialogModule

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { ChangePasswordComponent } from './auth/change-password/change-password.component';
import { UserProfileComponent } from './auth/user-profile/user-profile.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { HeaderComponent } from './home/header/header.component';
import { SidenavComponent } from './home/sidenav/sidenav.component';
import { DashboardComponent } from './home/dashboard/dashboard.component';
import { HomeComponent } from './home/home/home.component';
import { ProductTypeComponent } from './categories/product-type/product-type.component';
import { SubCategoryComponent } from './categories/sub-category/sub-category.component';
import { TaxCategoryComponent } from './categories/tax-category/tax-category.component';
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
import { SalesPersonAccountDetailsComponent } from './sales/sales-person-account-details/sales-person-account-details.component';
import { SendSmsComponent } from './settings/send.sms/send.sms.component';
import { AddProductTypeDialogComponent } from './dialogs/add-product-type-dialog/add-product-type-dialog.component';
import { AddCategoryTypeDialogComponent } from './dialogs/add-category-type-dialog/add-category-type-dialog.component';
import { AddSubCategoryDialogComponent } from './dialogs/add-sub-category-dialog/add-sub-category-dialog.component';
import { AddTaxCategoryDialogComponent } from './dialogs/add-tax-category-dialog/add-tax-category-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ChangePasswordComponent,
    UserProfileComponent,
    HeaderComponent,
    SidenavComponent,
    DashboardComponent,
    HomeComponent,
    ProductTypeComponent,
    SubCategoryComponent,
    TaxCategoryComponent,
    InventoryComponent,
    CustomerComponent,
    PowerDetailsComponent,
    ContactLensComponent,
    JobOrderComponent,
    DayCashComponent,
    PayRemainingComponent,
    ClientBalanceComponent,
    WorkshopManagerComponent,
    DamagedGoodComponent,
    ExchangeSaleReturnComponent,
    StockInComponent,
    StockOutComponent,
    SunglassComponent,
    SolutionComponent,
    SalesPersonAccountDetailsComponent,
    SendSmsComponent,
    AddProductTypeDialogComponent,
    AddCategoryTypeDialogComponent,
    AddSubCategoryDialogComponent,
    AddTaxCategoryDialogComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatGridListModule,
    MatSelectModule,
    MatTableModule,         // Correct import
    MatDialogModule         // Correct import
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
