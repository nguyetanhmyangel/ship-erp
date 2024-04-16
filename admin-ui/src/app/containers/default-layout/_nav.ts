import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' },
    attributes: {
      "policyName": "Permissions.Dashboard.View"
    }
  },
  {
    name: 'Features',
    url: '/feature',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Posts',
        url: '/feature/posts',
        attributes: {
          "policyName": "Permissions.Posts.View"
        }
      }
    ],
  },
  {
    name: 'Systems',
    url: '/system',
    iconComponent: { name: 'cil-notes' },
    children: [
      {
        name: 'Roles',
        url: '/system/roles',
        attributes: {
          "policyName": "Permissions.Roles.View"
        }

      },
      {
        name: 'Users',
        url: '/system/users',
        attributes: {
          "policyName": "Permissions.Dashboard.View"
        }
      }
    ],
  }
];
