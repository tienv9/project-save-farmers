<template>
  <ion-page>
    <ion-content>
      <div class="board">

        <!-- Search Row -->
        <div class="search-row">
          <ion-searchbar v-model="searchQuery" @ionInput="updateSearchQuery" placeholder="Search posts..."></ion-searchbar>
          <ion-button fill="outline" class="advanced-btn" @click="toggleAdvanced">
            {{ showAdvanced ? 'Hide Filters' : 'Advanced Search' }}
            <span class="filter-badge" v-if="hasActiveFilters">{{ activeFilterCount }}</span>
          </ion-button>
        </div>

        <!-- Advanced Search Panel -->
        <div v-if="showAdvanced" class="advanced-panel">
          <div class="advanced-header">
            <span class="advanced-title">Advanced Filters</span>
            <ion-button fill="clear" size="small" color="medium" @click="clearFilters">Clear All</ion-button>
          </div>

          <!-- Price Range -->
          <div class="filter-group">
            <p class="filter-label">Price Range ($)</p>
            <div class="range-inputs">
              <ion-item lines="none" class="range-item">
                <ion-input
                  label="Min"
                  label-placement="stacked"
                  type="number"
                  :value="minPrice ?? ''"
                  placeholder="0"
                  min="0"
                  @ionInput="(e: CustomEvent) => { minPrice = e.detail.value !== '' ? Number(e.detail.value) : null; filterPosts(); }"
                ></ion-input>
              </ion-item>
              <span class="range-separator">—</span>
              <ion-item lines="none" class="range-item">
                <ion-input
                  label="Max"
                  label-placement="stacked"
                  type="number"
                  :value="maxPrice ?? ''"
                  placeholder="Any"
                  min="0"
                  @ionInput="(e: CustomEvent) => { maxPrice = e.detail.value !== '' ? Number(e.detail.value) : null; filterPosts(); }"
                ></ion-input>
              </ion-item>
            </div>
          </div>

          <!-- Amount Range -->
          <div class="filter-group">
            <p class="filter-label">Amount Range</p>
            <div class="range-inputs">
              <ion-item lines="none" class="range-item">
                <ion-input
                  label="Min"
                  label-placement="stacked"
                  type="number"
                  :value="minAmount ?? ''"
                  placeholder="0"
                  min="0"
                  @ionInput="(e: CustomEvent) => { minAmount = e.detail.value !== '' ? Number(e.detail.value) : null; filterPosts(); }"
                ></ion-input>
              </ion-item>
              <span class="range-separator">—</span>
              <ion-item lines="none" class="range-item">
                <ion-input
                  label="Max"
                  label-placement="stacked"
                  type="number"
                  :value="maxAmount ?? ''"
                  placeholder="Any"
                  min="0"
                  @ionInput="(e: CustomEvent) => { maxAmount = e.detail.value !== '' ? Number(e.detail.value) : null; filterPosts(); }"
                ></ion-input>
              </ion-item>
            </div>
          </div>

          <!-- Location Filter -->
          <div class="filter-group">
            <ion-select
              v-model="selectedLocation"
              @ionChange="filterPosts"
              placeholder="All Locations"
              label="Location"
              label-placement="stacked"
            >
              <ion-select-option value="">All Locations</ion-select-option>
              <ion-select-option v-for="location in locations" :key="location" :value="location">
                {{ location }}
              </ion-select-option>
            </ion-select>
          </div>

          <!-- Crop Type Filter -->
          <div class="filter-group">
            <ion-select
              v-model="selectedCropTypes"
              @ionChange="filterPosts"
              multiple
              placeholder="All Crop Types"
              label="Crop Type"
              label-placement="stacked"
            >
              <ion-select-option v-for="crop in cropTypes" :key="crop" :value="crop">
                {{ crop }}
              </ion-select-option>
            </ion-select>
          </div>

          <!-- Expiry Date Range -->
          <div class="filter-group">
            <p class="filter-label">Expiry Date Range</p>
            <div class="range-inputs">
              <ion-item lines="none" class="range-item">
                <ion-input
                  label="From"
                  label-placement="stacked"
                  type="date"
                  :value="expiryFrom"
                  @ionInput="(e: CustomEvent) => { expiryFrom = e.detail.value ?? ''; filterPosts(); }"
                ></ion-input>
              </ion-item>
              <ion-item lines="none" class="range-item">
                <ion-input
                  label="To"
                  label-placement="stacked"
                  type="date"
                  :value="expiryTo"
                  @ionInput="(e: CustomEvent) => { expiryTo = e.detail.value ?? ''; filterPosts(); }"
                ></ion-input>
              </ion-item>
            </div>
          </div>

          <!-- Sort by Expiry Date -->
          <div class="filter-group">
            <ion-select
              v-model="sortExpiry"
              @ionChange="filterPosts"
              placeholder="No Sort"
              label="Sort by Expiry"
              label-placement="stacked"
            >
              <ion-select-option value="">No Sort</ion-select-option>
              <ion-select-option value="asc">Expires Soon First</ion-select-option>
              <ion-select-option value="desc">Expires Last First</ion-select-option>
            </ion-select>
          </div>
        </div>

        <!-- Display Filtered Posts -->
        <ion-card v-for="(post, index) in filteredPosts" :key="index" class="board-card">
          <ion-card-header>
            <ion-card-title>
              <img :src="postSer.getCropIcon(post.cropType)" alt="Crop Icon" class="crop-icon" />
              {{ post.title }}
            </ion-card-title>
          </ion-card-header>

          <div v-if="isMobileWidth">
            <ion-card-content>
              <div class="info-header">
                <span><strong>Produce: {{ post.cropType }}</strong></span>
                <span><strong>Price: ${{ post.price }}</strong></span>
                <span><strong>Amount: {{ post.amount }}</strong></span>
                <span><strong>Vendor: {{ post.userId }}</strong></span>
                <span><strong>Location: {{ post.location }}</strong></span>
                <span><strong>Contact: {{ postSer.formatContact(post.contact) }}</strong></span>
                <span><strong>Email: {{ post.name }}</strong></span>
                <span><strong>Date Listed: {{ formatDate(post.createDate) }}</strong></span>
              </div>
              <p class="expiry-date"><strong>Expires:</strong> {{ formatDate(post.expireDate) }}</p>
            </ion-card-content>
          </div>
          <div v-else>
            <ion-card-content>
              <div class="info-header">
                <span><strong>Produce:</strong></span>
                <span><strong>Price:</strong></span>
                <span><strong>Location:</strong></span>
                <span><strong>Contact:</strong></span>
              </div>
              <div class="info-details">
                <span>{{ post.cropType }}</span>
                <span>${{ post.price }}</span>
                <span>{{ post.location }}</span>
                <span>{{ postSer.formatContact(post.contact) }}</span>
              </div>
              <div class="info-2details">
                <span>{{ post.amount }}</span>
                <span class="date-column">
                  <div>Date Listed:</div>
                  <div>{{ formatDate(post.createDate) }}</div>
                </span>
                <span></span>
                <span>{{ post.name }}</span>
              </div>
              <p class="expiry-date"><strong>Expires:</strong> {{ formatDate(post.expireDate) }}</p>
            </ion-card-content>
          </div>
        </ion-card>
      </div>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import {
  IonCardTitle, IonCardHeader, IonCard, IonPage, IonCardContent,
  IonContent, IonSearchbar, IonSelect, IonSelectOption, IonButton,
  IonInput, IonItem,
} from '@ionic/vue';
import { useBoard } from '@/scripts/useBoard';

const {
  searchQuery,
  showAdvanced,
  minPrice,
  maxPrice,
  minAmount,
  maxAmount,
  selectedLocation,
  selectedCropTypes,
  expiryFrom,
  expiryTo,
  sortExpiry,
  filteredPosts,
  locations,
  cropTypes,
  hasActiveFilters,
  activeFilterCount,
  isMobileWidth,
  toggleAdvanced,
  clearFilters,
  updateSearchQuery,
  filterPosts,
  formatDate,
  postSer,
} = useBoard();
</script>



<style scoped>
.board {
  display: flex;
  flex-direction: column;
  gap: 0px;
  padding: 15px;
}

/* Search row: searchbar + advanced button */
.search-row {
  display: flex;
  align-items: center;
  gap: 8px;
  margin-bottom: 4px;
}

.search-row ion-searchbar {
  flex: 1;
  padding: 0;
  margin: 0;
}

.advanced-btn {
  flex-shrink: 0;
  position: relative;
  white-space: nowrap;
}

.filter-badge {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  background: var(--ion-color-primary);
  color: #fff;
  border-radius: 50%;
  font-size: 0.65rem;
  font-weight: bold;
  width: 16px;
  height: 16px;
  margin-left: 5px;
}

/* Advanced panel */
.advanced-panel {
  background: var(--ion-color-light);
  border: 1px solid var(--ion-color-medium-tint);
  border-radius: 8px;
  padding: 12px;
  margin-bottom: 10px;
}

.advanced-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 8px;
}

.advanced-title {
  font-weight: 600;
  font-size: 0.95rem;
}

.filter-group {
  margin-bottom: 12px;
}

.filter-group ion-select {
  width: 100%;
  border: 1px solid var(--ion-color-medium-tint);
  border-radius: 6px;
  padding: 4px 8px;
  background: var(--ion-color-light-shade);
}

.filter-label {
  font-size: 0.8rem;
  font-weight: 600;
  color: var(--ion-color-medium);
  margin: 0 0 4px 0;
}

.range-inputs {
  display: flex;
  align-items: flex-end;
  gap: 6px;
}

.range-item {
  flex: 1;
  --padding-start: 8px;
  --padding-end: 8px;
  border: 1px solid var(--ion-color-medium-tint);
  border-radius: 6px;
  background: var(--ion-color-light-shade);
}

.range-separator {
  font-size: 1rem;
  color: var(--ion-color-medium);
  padding-bottom: 10px;
  flex-shrink: 0;
}

/* Post cards */
.board-card {
  width: 100%;
  font-family: 'Courier New', Courier, monospace;
  margin-left: 0px;
  margin-right: 0px;
  margin-top: 0px;
}

.info-header {
  display: flex;
  font-weight: bold;
  font-size: 1.5rem;
}

.info-details {
  display: flex;
  font-size: 1.3rem;
}

.info-2details {
  display: flex;
  font-size: 1rem;
}

.info-header span,
.info-2details span,
.info-details span {
  flex: 1;
  flex-direction: column;
  text-align: left;
}

.date-column {
  display: flex;
  flex-direction: column;
  text-align: left;
  line-height: 1;
}

.date-column div:first-child {
  font-weight: bold;
  font-size: 0.9rem;
}

.expiry-date {
  margin-top: auto;
  text-align: right;
  font-size: 0.8rem;
  font-weight: bold;
}

.crop-icon {
  width: 1.5rem;
  height: auto;
  vertical-align: middle;
  margin-right: 8px;
}

ion-content {
  --padding-top: 50px;
}

@media (max-width: 850px) {
  .info-header, .info-details, .info-2details {
    flex-direction: column;
  }

  .info-header span, .info-2details span, .info-details span {
    flex: none;
    text-align: left;
  }

  .board-card {
    width: 100%;
  }

  .info-header {
    font-size: 1.2rem;
  }

  .info-details {
    font-size: 1.1rem;
  }

  .info-2details {
    font-size: 0.9rem;
  }

  .expiry-date {
    font-size: 0.7rem;
  }

  .crop-icon {
    width: 1.2rem;
  }
}

@media (max-width: 500px) {
  .search-row {
    flex-wrap: wrap;
  }

  .advanced-btn {
    width: 100%;
  }

  .range-inputs {
    flex-direction: column;
    align-items: stretch;
  }

  .range-separator {
    display: none;
  }

  .info-header {
    font-size: 1rem;
  }

  .info-details {
    font-size: 1rem;
  }

  .info-2details {
    font-size: 0.9rem;
  }

  .date-column div:first-child {
    font-size: 0.7rem;
  }

  .expiry-date {
    font-size: 0.6rem;
  }

  .crop-icon {
    width: 1rem;
  }
}
</style>
