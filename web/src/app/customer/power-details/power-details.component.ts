import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

interface CustomerPower{
  id: string;
  customerName: string;
  address: string;
  contactNo: string;
  alternateContact: string;
  age: string;
  gender: string;
  email: string;
  rsph: string;
  rcyl: string;
  raxis: string;
  rvn: string;
  radd: string;
  lsph: string;
  lcyl: string;
  laxis: string;
  lvn: string;
  ladd: string;
  pd: string;
  refBy: string;
  lensType: string;
  bookingDate: string;
  remarks: string;
  prgRight: string;
  prgLeft: string;
  ppLeft: string;
  ppRight: string;
  ppAdd: string;
}

interface PaginatedInventoryResponse {
  items: CustomerPower[];
  totalItems: number;
}

@Component({
  selector: 'app-power-details',
  templateUrl: './power-details.component.html',
  styleUrl: './power-details.component.css'
})
export class PowerDetailsComponent implements OnInit{
  customerPowerForm: FormGroup;

  selectedCustomerId: string | null = null;

  displayedColumns: string[] = ['customerName', 'contact', 'alternateContact', 'bookingDate', 'refBy', 'remarks', 'actions'];

  customerPowers: CustomerPower[] = [];
  totalItems = 0;
  pageSize = 10;
  pageIndex = 0;

  constructor(
    private router: Router,
    private http: HttpClient,
    private snackBar: MatSnackBar,
    private fb: FormBuilder
  ) {
    this.customerPowerForm = this.fb.group({
      customerName: [''],
      address: [''],
      contactNo: [''],
      alternateContact: [''],
      age: [''],
      gender: [''],
      email: [''],
      rsph: [''],
      rcyl: [''],
      raxis: [''],
      rvn: [''],
      radd: [''],
      lsph: [''],
      lcyl: [''],
      laxis: [''],
      lvn: [''],
      ladd: [''],
      pd: [''],
      refBy: [''],
      lensType: [''],
      bookingDate: [''],
      prgRight: [''],
      prgLeft: [''],
      ppRight: [''],
      ppLeft: [''],
      ppAdd: [''],
      remarks: ['']
    });
  }

  ngOnInit(): void {
    this.loadCustomerPowers(this.pageIndex + 1, this.pageSize);
  }

  private handleError(type: string, error: any): void {
    console.error(`Error loading ${type}:`, error);
    this.snackBar.open(`Error loading ${type}`, 'Close', { duration: 2000 });
  }

  saveCustomerPower(): void {
    if (!this.customerPowerForm.valid) {
      this.snackBar.open('Please fill in all required fields.', 'Close', { duration: 2000 });
      return;
    }

    // Create the separate customer and power details
  const customerDetails = {
    customerName: this.customerPowerForm.get('customerName')?.value,
    address: this.customerPowerForm.get('address')?.value ?? '',
    contactNo: this.customerPowerForm.get('contactNo')?.value ?? '',
    alternateContact: this.customerPowerForm.get('alternateContact')?.value ?? '',
    age: this.customerPowerForm.get('age')?.value ?? '',
    gender: this.customerPowerForm.get('gender')?.value ?? '',
    email: this.customerPowerForm.get('email')?.value ?? '',
    remarks: this.customerPowerForm.get('remarks')?.value ?? ''
  };

  const powerDetails = {
    rsph: this.customerPowerForm.get('rsph')?.value ?? '',
    rcyl: this.customerPowerForm.get('rcyl')?.value ?? '',
    raxis: this.customerPowerForm.get('raxis')?.value ?? '',
    rvn: this.customerPowerForm.get('rvn')?.value ?? '',
    radd: this.customerPowerForm.get('radd')?.value ?? '',
    lsph: this.customerPowerForm.get('lsph')?.value ?? '',
    lcyl: this.customerPowerForm.get('lcyl')?.value ?? '',
    laxis: this.customerPowerForm.get('laxis')?.value ?? '',
    lvn: this.customerPowerForm.get('lvn')?.value ?? '',
    ladd: this.customerPowerForm.get('ladd')?.value ?? '',
    pd: this.customerPowerForm.get('pd')?.value ?? '',
    refBy: this.customerPowerForm.get('refBy')?.value ?? '',
    lensType: this.customerPowerForm.get('lensType')?.value ?? '',
    bookingDate: this.customerPowerForm.get('bookingDate')?.value ?? '',
    prgRight: this.customerPowerForm.get('prgRight')?.value ?? '',
    prgLeft: this.customerPowerForm.get('prgLeft')?.value ?? '',
    ppRight: this.customerPowerForm.get('ppRight')?.value ?? '',
    ppLeft: this.customerPowerForm.get('ppLeft')?.value ?? '',
    ppAdd: this.customerPowerForm.get('ppAdd')?.value ?? '',
    remarks: this.customerPowerForm.get('remarks')?.value ?? ''
  };

  const payload = {
    customerDetails: customerDetails,
    powerDetails: powerDetails
  };
    console.log("CreatePowerDetails", payload);
    this.http.post(`${environment.apiUrl}/CustomerPower/CreatePowerDetails`, payload)
      .subscribe(
        () => {
          this.snackBar.open('Power saved successfully', 'Close', { duration: 2000 },);
          this.customerPowerForm.reset(); // Reset the form after successful submission
          this.loadCustomerPowers(this.pageIndex + 1, this.pageSize);
        },
        error => this.handleError('inventory', error)
      );
  }

  editCustomerPowerList(item: CustomerPower): void {
    this.selectedCustomerId = item.id;
    this.customerPowerForm.reset();

    this.customerPowerForm.patchValue({
      id: item.id,
      customerName: item.customerName,
      address: item.address,
      contactNo: item.contactNo,
      alternateContact: item.alternateContact,
      rsph: item.rsph,
      rcyl: item.rcyl,
      raxis: item.raxis,
      rvn: item.rvn,
      radd: item.radd,
      lsph: item.lsph,
      lcyl: item.lcyl,
      laxis: item.laxis,
      lvn: item.lvn,
      ladd: item.ladd,
      pd: item.pd,
      refBy: item.refBy,
      lensType: item.lensType,
      bookingDate: item.bookingDate,
      prgRight: item.prgRight,
      prgLeft: item.prgLeft,
      ppRight: item.ppRight,
      ppLeft: item.ppLeft,
      ppAdd: item.ppAdd,
      remarks: item.remarks
    });
  }

  updateCustomerPower() {
    if (!this.customerPowerForm.valid) {
      this.snackBar.open('Please fill in all required fields.', 'Close', { duration: 2000 });
      return;
    }

    // Create the separate customer and power details
    const customerDetails = {
      customerName: this.customerPowerForm.get('customerName')?.value,
      address: this.customerPowerForm.get('address')?.value ?? '',
      contactNo: this.customerPowerForm.get('contactNo')?.value ?? '',
      alternateContact: this.customerPowerForm.get('alternateContact')?.value ?? '',
      age: this.customerPowerForm.get('age')?.value ?? '',
      gender: this.customerPowerForm.get('gender')?.value ?? '',
      email: this.customerPowerForm.get('email')?.value ?? '',
      remarks: this.customerPowerForm.get('remarks')?.value ?? ''
    };

    const powerDetails = {
      id: this.selectedCustomerId,
      rsph: this.customerPowerForm.get('rsph')?.value ?? '',
      rcyl: this.customerPowerForm.get('rcyl')?.value ?? '',
      raxis: this.customerPowerForm.get('raxis')?.value ?? '',
      rvn: this.customerPowerForm.get('rvn')?.value ?? '',
      radd: this.customerPowerForm.get('radd')?.value ?? '',
      lsph: this.customerPowerForm.get('lsph')?.value ?? '',
      lcyl: this.customerPowerForm.get('lcyl')?.value ?? '',
      laxis: this.customerPowerForm.get('laxis')?.value ?? '',
      lvn: this.customerPowerForm.get('lvn')?.value ?? '',
      ladd: this.customerPowerForm.get('ladd')?.value ?? '',
      pd: this.customerPowerForm.get('pd')?.value ?? '',
      refBy: this.customerPowerForm.get('refBy')?.value ?? '',
      lensType: this.customerPowerForm.get('lensType')?.value ?? '',
      bookingDate: this.customerPowerForm.get('bookingDate')?.value ?? '',
      prgRight: this.customerPowerForm.get('prgRight')?.value ?? '',
      prgLeft: this.customerPowerForm.get('prgLeft')?.value ?? '',
      ppRight: this.customerPowerForm.get('ppRight')?.value ?? '',
      ppLeft: this.customerPowerForm.get('ppLeft')?.value ?? '',
      ppAdd: this.customerPowerForm.get('ppAdd')?.value ?? '',
      remarks: this.customerPowerForm.get('remarks')?.value ?? ''
    };

    const payload = {
      customerDetails: customerDetails,
      powerDetails: powerDetails
    };

    this.http.put(`${environment.apiUrl}/CustomerPower/UpdatePowerDetails`, payload)
      .subscribe(
        () => {
          this.snackBar.open('Power updated successfully', 'Close', { duration: 2000 },);
          this.customerPowerForm.reset(); // Reset the form after successful submission
          this.loadCustomerPowers(this.pageIndex + 1, this.pageSize);
        },
        error => this.handleError('inventory', error)
      );
  }

  deleteCustomerPower(): void {
    if (!this.selectedCustomerId) {
      this.snackBar.open('No customer power selected for deletion.', 'Close', { duration: 2000 });
      return;
    }

    const payload = { id: this.selectedCustomerId };

    this.http.delete(`${environment.apiUrl}/CustomerPower/DeletePowerDetail?id=${this.selectedCustomerId}`)
    .subscribe(
      () => {
        this.snackBar.open('Power deleted successfully', 'Close', { duration: 2000 });
        this.customerPowerForm.reset();
        this.selectedCustomerId = null; // Reset the selected item ID after deletion
        this.loadCustomerPowers(this.pageIndex + 1, this.pageSize); // Refresh the inventory list after deletion
      },
      error => this.handleError('inventory', error)
    );
  }

  loadCustomerPowers(page: number, pageSize: number) {
    this.http.get<PaginatedInventoryResponse>(`${environment.apiUrl}/CustomerPower/PowerDetailsList?page=${page}&pageSize=${pageSize}`)
      .subscribe(
        (data) => {
          this.customerPowers = data.items;
          this.totalItems = data.totalItems;
        },
        (error) => {
          console.error('Error loading inventory product:', error);
        }
      );
  }

  onPageChange(event: PageEvent): void {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.loadCustomerPowers(this.pageIndex + 1, this.pageSize);
  }

  close(): void {
    this.router.navigate([`/home`]);
  }
}
