import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { PageEvent } from '@angular/material/paginator';

interface Customer {
  id: string;
  customerName: string;
  address: string;
  contactNo: string;
  alternateContact: string;
  age: string;
  gender: string;
  email: string;
  remarks: string;
}

interface PaginatedInventoryResponse {
  items: Customer[];
  totalItems: number;
}

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent implements OnInit{
  customerForm: FormGroup;

  selectedCustomerId: string | null = null;

  displayedColumns: string[] = ['customerName', 'contactNo', 'alternateContact', 'actions'];

  customerItems: Customer[] = [];
  totalItems = 0;
  pageSize = 10;
  pageIndex = 0;

  constructor(
    private router: Router,
    private http: HttpClient,
    private snackBar: MatSnackBar,
    private fb: FormBuilder,
    private cdr: ChangeDetectorRef
  ) {
    this.customerForm = this.fb.group({
      customerName: ['', Validators.required],
      address: ['', Validators.required],
      contactNo: ['', Validators.required],
      alternateContact: ['', Validators.required],
      age: ['', Validators.required],
      gender: ['', Validators.required],
      email: ['', Validators.required],
      remarks: ['', Validators.required],
    });
  }

  ngOnInit(): void {
      this.loadCustomerList(this.pageIndex + 1, this.pageSize)
  }

  editCustomerList(item: Customer): void {
    this.selectedCustomerId = item.id;  // Check if `item` contains expected properties and values

    this.customerForm.reset();
    this.customerForm.patchValue({
      id: item.id,
      customerName: item.customerName,
      address: item.address,
      contactNo: item.contactNo,
      alternateContact: item.alternateContact,
      age: item.age,
      gender: item.gender,
      email: item.email,
      remarks: item.remarks,
    });

    this.cdr.detectChanges();
    console.log('Form values after patch:', this.customerForm.value); // Check the form values
  }

  loadCustomerList(page: number, pageSize: number): void{
    this.http.get<PaginatedInventoryResponse>(`${environment.apiUrl}/Customer/GetCustomers?page=${page}&pageSize=${pageSize}`)
      .subscribe(
        (data) => {
          this.customerItems = data.items;
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
    this.loadCustomerList(this.pageIndex + 1, this.pageSize);
  }

  private handleError(type: string, error: any): void {
    console.error(`Error loading ${type}:`, error);
    this.snackBar.open(`Error loading ${type}`, 'Close', { duration: 2000 });
  }

  saveCustomer(): void {
    if (!this.customerForm.valid) {
      this.snackBar.open('Please fill in all required fields.', 'Close', { duration: 2000 });
      return;
    }

    const payload: Customer = this.customerForm.value;
    this.http.post(`${environment.apiUrl}/Customer/CreateCustomer`, payload)
      .subscribe(
        () => {
          this.snackBar.open('Customer saved successfully', 'Close', { duration: 2000 },);
          this.loadCustomerList(this.pageIndex + 1, this.pageSize);
          this.customerForm.reset(); // Reset the form after successful submission
        },
        error => this.handleError('inventory', error)
      );
  }

  updateCustomer(): void {
    if (!this.customerForm.valid) {
      this.snackBar.open('Please fill in all required fields.', 'Close', { duration: 2000 });
      return;
    }

    if (!this.selectedCustomerId) {
      this.snackBar.open('No customer selected for update.', 'Close', { duration: 2000 });
      return;
    }

    const payload: Customer = this.customerForm.value;
    payload.id = this.selectedCustomerId;

    this.http.put(`${environment.apiUrl}/Customer/UpdateCustomer`, payload)
      .subscribe(
        () => {
          this.snackBar.open('Customer updated successfully', 'Close', { duration: 2000 });
          // Reload the inventory list after updating
          this.loadCustomerList(this.pageIndex + 1, this.pageSize);
          // Reset the form after successful update
          this.customerForm.reset();
          this.selectedCustomerId = null; // Reset selected inventory item
        },
        error => this.handleError('inventory', error)
      );
  }

  deleteCustomer(): void {
    if (!this.selectedCustomerId) {
      this.snackBar.open('No customer selected for deletion.', 'Close', { duration: 2000 });
      return;
    }

    const payload = { id: this.selectedCustomerId };

    this.http.delete(`${environment.apiUrl}/Customer/DeleteCustomer?id=${this.selectedCustomerId}`)
    .subscribe(
      () => {
        this.snackBar.open('Customer deleted successfully', 'Close', { duration: 2000 });
        this.customerForm.reset();
        this.selectedCustomerId = null; // Reset the selected item ID after deletion
        this.loadCustomerList(this.pageIndex + 1, this.pageSize); // Refresh the inventory list after deletion
      },
      error => this.handleError('inventory', error)
    );
  }

  close(): void {
    this.router.navigate([`/home`]);
  }
}
