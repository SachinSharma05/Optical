import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddSubCategoryDialogComponent } from '../../dialogs/add-sub-category-dialog/add-sub-category-dialog.component';
import { AddCategoryTypeDialogComponent } from '../../dialogs/add-category-type-dialog/add-category-type-dialog.component';
import { AddProductTypeDialogComponent } from '../../dialogs/add-product-type-dialog/add-product-type-dialog.component';

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

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {
  productTypes: ItemType[] = []; // Initialize as an empty array
  categoryTypes: CategoryType[] = []; // Initialize as an empty array
  subCategoriesType: SubCategoryType[] = []; // Initialize as an empty array
  taxCategories: TaxCategoryType[] = []; // Initialize as an empty array

  inventoryForm: FormGroup;

  inventoryItems = new MatTableDataSource([
    { productName: 'Product 1', stock: 50, price: 100 },
    { productName: 'Product 2', stock: 30, price: 150 }
  ]);

  displayedColumns: string[] = ['productName', 'stock', 'price'];

  constructor(
    private http: HttpClient,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private fb: FormBuilder
  ) {
    this.inventoryForm = this.fb.group({
      product_type: ['', Validators.required],
      category_name: ['', Validators.required],
      sub_category_name: ['', Validators.required],
      product_name: ['', Validators.required],
      selling_price: ['', Validators.required],
      stock_reorder_point: ['', Validators.required],
      stock_limit: ['', Validators.required],
      tax_category: ['', Validators.required],
      stock_in_hand: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadData();
  }

  private loadData(): void {
    const loadFunctions = [
      this.loadProductTypes(),
      this.loadCategoryTypes(),
      this.loadSubCategoryTypes(),
      this.loadTaxCategories()
    ];
    Promise.all(loadFunctions).catch(error => {
      console.error('Error loading data:', error);
    });
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
          this.snackBar.open('Inventory saved successfully', 'Close', { duration: 2000 });
          this.inventoryForm.reset(); // Reset the form after successful submission
        },
        error => this.handleError('inventory', error)
      );
  }

  // Placeholder methods for update and delete functionalities
  updateInventory(): void {
    // Implement update logic here
  }

  deleteInventory(): void {
    // Implement delete logic here
  }

  close(): void {

  }
}
