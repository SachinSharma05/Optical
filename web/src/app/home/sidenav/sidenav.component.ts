import { Component } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.css'
})
export class SidenavComponent {
  isMobile = false;
  expandedSection: string | null = null; // Keeps track of expanded menu

  toggleExpand(section: string) {
    this.expandedSection = this.expandedSection === section ? null : section;
  }
}
