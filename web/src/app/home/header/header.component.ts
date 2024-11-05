import { Component, OnInit, ViewChild  } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from '../../../auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @ViewChild(MatSidenav) sidenav!: MatSidenav;
  isMobile = false;
  isCollapsed = true;

  constructor(private breakpointObserver: BreakpointObserver, private authService: AuthService) {}

  onLogout() {
    this.authService.logout();
  }

  ngOnInit() {
    this.breakpointObserver
      .observe([Breakpoints.HandsetPortrait, Breakpoints.HandsetLandscape])
      .pipe(map(result => result.matches))
      .subscribe(isHandset => {
        this.isMobile = isHandset;
        if (isHandset) {
          this.sidenav.close(); // Close on mobile initially
        }
      });
  }

  toggleMenu() {
    if (this.isMobile) {
      this.sidenav.toggle();
    } else {
      this.isCollapsed = !this.isCollapsed;
    }
  }
}
