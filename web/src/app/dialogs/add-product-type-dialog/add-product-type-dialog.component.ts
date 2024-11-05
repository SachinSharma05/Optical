import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-product-type-dialog',
  templateUrl: './add-product-type-dialog.component.html',
  styleUrl: './add-product-type-dialog.component.css'
})
export class AddProductTypeDialogComponent {
  productTypeForm: FormGroup;

  constructor(
    private dialogRef: MatDialogRef<AddProductTypeDialogComponent>,
    private fb: FormBuilder
    ) {
    this.productTypeForm = this.fb.group({
      productName: ['', Validators.required],
    });
  }

  onSave() {
    if (this.productTypeForm.valid) {
      this.dialogRef.close(this.productTypeForm.value); // Pass form data to the parent component
    }
  }

  onCancel() {
    this.dialogRef.close();
  }
}
