import '../styles/site.css';

import 'alpinejs';
import axios from "axios";
import { library, dom } from "@fortawesome/fontawesome-svg-core";
import { fas } from '@fortawesome/free-solid-svg-icons';
import { far } from '@fortawesome/free-regular-svg-icons';
import { fab } from '@fortawesome/free-brands-svg-icons';

library.add(fas, far, fab);
dom.watch();

interface User{
    id:number,
    firstName: string,
    lastName: string
}

export function setupNav() {
    return {
        toggleMenu() {
            var headerNav = document.getElementById('headerNav');
            if (headerNav) {
                if (headerNav.classList.contains('hidden')) {
                    headerNav.classList.remove('hidden');
                } else {
                    headerNav.classList.add('hidden');
                }
            }
        }
    }
}

export function setupUsers() {
    return {
        users: [] as User[],
        async mounted() {
            await this.loadUsers();
        },
        async deleteUser(currentUser: User) {
            if (confirm(`Are you sure you want to delete ${currentUser.firstName} ${currentUser.lastName}?`)) {
                await axios.delete(`https://localhost:5101/api/users/${currentUser.id}`);
                await this.loadUsers();
            }
        },
        async loadUsers() {
            try {
                const response = await axios.get("https://localhost:5101/api/users");
                this.users = response.data;
            } catch (error) {
                console.log(error);
            }
        }
    }
}