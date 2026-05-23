import { ref, computed, onMounted, watch } from 'vue';
import { postSer } from '@/scripts/PostService';

export function useBoard() {
  const posts = computed(() => postSer.posts.value);

  // General search
  const searchQuery = ref('');

  // Advanced search state
  const showAdvanced = ref(false);
  const minPrice = ref<number | null>(null);
  const maxPrice = ref<number | null>(null);
  const minAmount = ref<number | null>(null);
  const maxAmount = ref<number | null>(null);
  const selectedLocation = ref('');
  const selectedCropTypes = ref<string[]>([]);
  const expiryFrom = ref('');
  const expiryTo = ref('');
  const sortExpiry = ref('');

  const filteredPosts = ref(posts.value);

  const locations = computed(() => [...new Set(posts.value.map(post => post.location))]);
  const cropTypes = computed(() => [...new Set(posts.value.map(post => post.cropType))]);

  const hasActiveFilters = computed(() =>
    minPrice.value !== null ||
    maxPrice.value !== null ||
    minAmount.value !== null ||
    maxAmount.value !== null ||
    !!selectedLocation.value ||
    selectedCropTypes.value.length > 0 ||
    !!sortExpiry.value ||
    !!expiryFrom.value ||
    !!expiryTo.value
  );

  const activeFilterCount = computed(() => {
    let count = 0;
    if (minPrice.value !== null) count++;
    if (maxPrice.value !== null) count++;
    if (minAmount.value !== null) count++;
    if (maxAmount.value !== null) count++;
    if (selectedLocation.value) count++;
    if (selectedCropTypes.value.length > 0) count++;
    if (sortExpiry.value) count++;
    if (expiryFrom.value) count++;
    if (expiryTo.value) count++;
    return count;
  });

  const toggleAdvanced = () => {
    showAdvanced.value = !showAdvanced.value;
  };

  const clearFilters = () => {
    minPrice.value = null;
    maxPrice.value = null;
    minAmount.value = null;
    maxAmount.value = null;
    selectedLocation.value = '';
    selectedCropTypes.value = [];
    sortExpiry.value = '';
    expiryFrom.value = '';
    expiryTo.value = '';
    filterPosts();
  };

  const updateSearchQuery = (event: CustomEvent) => {
    searchQuery.value = event.detail.value;
  };

  const formatDate = (dateString: string): string => {
    const date = new Date(dateString);
    return date.toLocaleString();
  };

  const filterPosts = () => {
    let filtered = posts.value;

    if (searchQuery.value) {
      const query = searchQuery.value.toLowerCase();
      filtered = filtered.filter(post =>
        post.title.toLowerCase().includes(query) ||
        post.cropType.toLowerCase().includes(query) ||
        post.userId.toLowerCase().includes(query) ||
        post.location.toLowerCase().includes(query) ||
        postSer.formatContact(post.contact).toLowerCase().includes(query) ||
        post.price.toString().includes(query) ||
        post.amount.toString().includes(query)
      );
    }

    if (minPrice.value !== null) {
      filtered = filtered.filter(post => post.price >= minPrice.value!);
    }
    if (maxPrice.value !== null) {
      filtered = filtered.filter(post => post.price <= maxPrice.value!);
    }

    if (minAmount.value !== null) {
      filtered = filtered.filter(post => Number(post.amount) >= minAmount.value!);
    }
    if (maxAmount.value !== null) {
      filtered = filtered.filter(post => Number(post.amount) <= maxAmount.value!);
    }

    if (selectedLocation.value) {
      filtered = filtered.filter(post => post.location === selectedLocation.value);
    }

    if (selectedCropTypes.value.length > 0) {
      filtered = filtered.filter(post => selectedCropTypes.value.includes(post.cropType));
    }

    if (expiryFrom.value) {
      const from = new Date(expiryFrom.value).getTime();
      filtered = filtered.filter(post => new Date(post.expireDate).getTime() >= from);
    }
    if (expiryTo.value) {
      const to = new Date(expiryTo.value).getTime();
      filtered = filtered.filter(post => new Date(post.expireDate).getTime() <= to);
    }

    if (sortExpiry.value) {
      filtered = [...filtered].sort((a, b) => {
        const dateA = new Date(a.expireDate).getTime();
        const dateB = new Date(b.expireDate).getTime();
        return sortExpiry.value === 'asc' ? dateA - dateB : dateB - dateA;
      });
    }

    filteredPosts.value = filtered;
  };

  // Screen size detection
  const isMobileWidth = ref(false);
  const checkScreenWidth = () => {
    isMobileWidth.value = window.innerWidth < 850;
  };

  watch(searchQuery, filterPosts);

  onMounted(async () => {
    checkScreenWidth();
    window.addEventListener('resize', checkScreenWidth);
    await postSer.fetchPosts();
    filteredPosts.value = posts.value;
  });

  return {
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
  };
}
