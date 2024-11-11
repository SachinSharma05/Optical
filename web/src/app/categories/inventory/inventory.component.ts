import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ChangeDetectorRef } from '@angular/core';
import { AddSubCategoryDialogComponent } from '../../dialogs/add-sub-category-dialog/add-sub-category-dialog.component';
import { AddCategoryTypeDialogComponent } from '../../dialogs/add-category-type-dialog/add-category-type-dialog.component';
import { AddProductTypeDialogComponent } from '../../dialogs/add-product-type-dialog/add-product-type-dialog.component';
import { Router } from '@angular/router';
import { PageEvent } from '@angular/material/paginator';

interface ItemType {
  id: number;
  productName: string;
}

interface CategoryType {
  id: number;
  productName: string;
  categoryName: string;
}

interface SubCategoryType {
  id: number;
  productName: string;
  categoryName: string;
  subCategoryName: string;
}

interface TaxCategoryType {
  id: number;
  taxPercent: string;
}

interface Inventory {
  id: string;
  productType: string;
  categoryName: string;
  subCategoryName: string;
  productName: string;
  sellingPrice: string;
  stockReorderPoint: string;
  stockLimit: string;
  taxCategory: string;
  stockInHand: string;
}

interface PaginatedInventoryResponse {
  items: Inventory[];
  totalItems: number;
}

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {
  productTypes: ItemType[] = [];
  categoryTypes: CategoryType[] = [];
  subCategoriesType: SubCategoryType[] = [];
  taxCategories: TaxCategoryType[] = [];
  inventoryForm: FormGroup;

  selectedInventoryId: string | null = null;

  // inventoryItems = new MatTableDataSource<Inventory>([]);
  displayedColumns: string[] = ['productName', 'categoryName', 'sellingPrice', 'stockInHand', 'actions'];

  inventoryItems: Inventory[] = [];
  totalItems = 0;
  pageSize = 10;
  pageIndex = 0;

  constructor(
    private router: Router,
    private http: HttpClient,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private fb: FormBuilder,
    private cdr: ChangeDetectorRef
  ) {
    this.inventoryForm = this.fb.group({
      productType: ['', Validators.required],
      categoryName: ['', Validators.required],
      subCategoryName: ['', Validators.required],
      productName: ['', Validators.required],
      sellingPrice: ['', Validators.required],
      stockReorderPoint: ['', Validators.required],
      stockLimit: ['', Validators.required],
      taxCategory: ['', Validators.required],
      stockInHand: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadProductTypes(),
      this.loadCategoryTypes(),
      this.loadSubCategoryTypes(),
      this.loadTaxCategories(),
      this.loadInventoryProduct(this.pageIndex + 1, this.pageSize)
  }

  editInventoryItem(item: Inventory): void {
    this.selectedInventoryId = item.id;  // Check if `item` contains expected properties and values

    this.inventoryForm.reset();
    this.inventoryForm.patchValue({
      id: item.id,
      productType: item.productType,
      categoryName: item.categoryName,
      subCategoryName: item.subCategoryName,
      productName: item.productName,
      sellingPrice: item.sellingPrice,
      stockReorderPoint: item.stockReorderPoint,
      stockLimit: item.stockLimit,
      taxCategory: item.taxCategory,
      stockInHand: item.stockInHand,
    });

    this.cdr.detectChanges();
    console.log('Form values after patch:', this.inventoryForm.value); // Check the form values
  }


  loadProductTypes(): void {
    this.http.get<ItemType[]>(`${environment.apiUrl}/Categories/GetProductType`)
      .subscribe(
        (data) => {
          this.productTypes = data;
        },
        (error) => {
          console.error('Error loading product types:', error);
        }
      );
  }

  loadCategoryTypes(): void {
    this.http.get<CategoryType[]>(`${environment.apiUrl}/Categories/GetCategoryType`)
      .subscribe(
        (data) => {
          this.categoryTypes = data;
        },
        (error) => {
          console.error('Error loading product types:', error);
        }
      );
  }

  loadSubCategoryTypes(): void {
    this.http.get<SubCategoryType[]>(`${environment.apiUrl}/Categories/GetSubCategoryType`)
      .subscribe(
        (data) => {
          this.subCategoriesType = data;
        },
        (error) => {
          console.error('Error loading product types:', error);
        }
      );
  }

  loadTaxCategories(): void {
    this.http.get<TaxCategoryType[]>(`${environment.apiUrl}/Categories/GetTaxCategories`)
      .subscribe(
        (data) => {
          this.taxCategories = data;
        },
        (error) => {
          console.error('Error loading product types:', error);
        }
      );
  }

  loadInventoryProduct(page: number, pageSize: number): void {
    this.http.get<PaginatedInventoryResponse>(`${environment.apiUrl}/Categories/GetInventoryList?page=${page}&pageSize=${pageSize}`)
      .subscribe(
        (data) => {
          this.inventoryItems = data.items;
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
    this.loadInventoryProduct(this.pageIndex + 1, this.pageSize);
  }

  private handleError(type: string, error: any): void {
    console.error(`Error loading ${type}:`, error);
    this.snackBar.open(`Error loading ${type}`, 'Close', { duration: 2000 });
  }

  openDialog(dialogComponent: any, saveFunction: (data: any) => void): void {
    const dialogRef = this.dialog.open(dialogComponent);
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        saveFunction(result);
      }
    });
  }

  openAddProductTypeDialog(): void {
    this.openDialog(AddProductTypeDialogComponent, this.saveProductType.bind(this));
  }

  openAddCategoryTypeDialog(): void {
    this.openDialog(AddCategoryTypeDialogComponent, this.saveCategoryType.bind(this));
  }

  openAddSubCategoryDialog(): void {
    this.openDialog(AddSubCategoryDialogComponent, this.saveSubCategory.bind(this));
  }

  private saveProductType(data: any): void {
    this.http.post(`${environment.apiUrl}/Categories/CreateProduct`, data)
      .subscribe(
        () => this.handleSuccess('Product type saved successfully', this.loadProductTypes),
        error => this.handleError('product type', error)
      );
  }

  private saveCategoryType(data: any): void {
    const payload = {
      Type: data.productName,
      categoryName: data.categoryName
    };
    this.http.post(`${environment.apiUrl}/Categories/CreateCategory`, payload)
      .subscribe(
        () => this.handleSuccess('Category saved successfully', this.loadCategoryTypes),
        error => this.handleError('category', error)
      );
  }

  private saveSubCategory(data: any): void {
    this.http.post(`${environment.apiUrl}/Categories/CreateSubCategory`, data)
      .subscribe(
        () => this.handleSuccess('Sub-category saved successfully', this.loadSubCategoryTypes),
        error => this.handleError('sub-category', error)
      );
  }

  private handleSuccess(message: string, reloadFunction: () => void): void {
    this.snackBar.open(message, 'Close', { duration: 2000 });
    reloadFunction();
  }

  saveInventory(): void {
    if (!this.inventoryForm.valid) {
      this.snackBar.open('Please fill in all required fields.', 'Close', { duration: 2000 });
      return;
    }

    const payload: Inventory = this.inventoryForm.value;
    this.http.post(`${environment.apiUrl}/Categories/CreateInventory`, payload)
      .subscribe(
        () => {
          this.snackBar.open('Inventory saved successfully', 'Close', { duration: 2000 },);
          this.loadInventoryProduct(this.pageIndex + 1, this.pageSize);
          this.inventoryForm.reset(); // Reset the form after successful submission
        },
        error => this.handleError('inventory', error)
      );
  }

  // Placeholder methods for update and delete functionalities
  updateInventory(): void {
    if (!this.inventoryForm.valid) {
      this.snackBar.open('Please fill in all required fields.', 'Close', { duration: 2000 });
      return;
    }

    // Check if selectedInventoryId is null or undefined
    if (!this.selectedInventoryId) {
      this.snackBar.open('No inventory item selected for update.', 'Close', { duration: 2000 });
      return;
    }

    // Set the id from the selectedInventoryId, which is now guaranteed to be a string
    const payload: Inventory = this.inventoryForm.value;
    payload.id = this.selectedInventoryId;

    // Call the PUT API to update the inventory item
    this.http.put(`${environment.apiUrl}/Categories/UpdateProduct`, payload)
      .subscribe(
        () => {
          this.snackBar.open('Inventory updated successfully', 'Close', { duration: 2000 });
          // Reload the inventory list after updating
          this.loadInventoryProduct(this.pageIndex + 1, this.pageSize);
          // Reset the form after successful update
          this.inventoryForm.reset();
          this.selectedInventoryId = null; // Reset selected inventory item
        },
        error => this.handleError('inventory', error)
      );
  }

  deleteInventory(): void {
    if (!this.selectedInventoryId) {
      this.snackBar.open('No inventory item selected for deletion.', 'Close', { duration: 2000 });
      return;
    }

    // Call your backend API to delete the item
    const payload = { id: this.selectedInventoryId };

    this.http.delete(`${environment.apiUrl}/Categories/DeleteInventoryById?id=${this.selectedInventoryId}`)
    .subscribe(
      () => {
        this.snackBar.open('Item deleted successfully', 'Close', { duration: 2000 });
        this.inventoryForm.reset();
        this.selectedInventoryId = null; // Reset the selected item ID after deletion
        this.loadInventoryProduct(this.pageIndex + 1, this.pageSize); // Refresh the inventory list after deletion
      },
      error => this.handleError('inventory', error)
    );
  }

  close(): void {
    this.router.navigate([`/home`]);
  }
}
