import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

interface ItemType {
  id: number;
  productName: string;
}

interface CategoryType{
  id: number;
  productName: string;
  categoryName: string;
}

@Component({
  selector: 'app-add-category-type-dialog',
  templateUrl: './add-category-type-dialog.component.html',
  styleUrl: './add-category-type-dialog.component.css'
})
export class AddCategoryTypeDialogComponent implements OnInit {
  productTypes: ItemType[] = [];
  categoryTypes: CategoryType[] = [];
  categoryForm: FormGroup;

  constructor(
    private http: HttpClient,
    private dialogRef: MatDialogRef<AddCategoryTypeDialogComponent>,
    private fb: FormBuilder
  ) {
    this.categoryForm = this.fb.group({
      productName: ['', Validators.required],
      categoryName: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadProductTypes();
    this.loadCategoryTypes();
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

  onSave() {
    if (this.categoryForm.valid) {
      this.dialogRef.close(this.categoryForm.value); // Pass form data to the parent component
    }
  }

  onCancel() {
    this.dialogRef.close();
  }
}
