📱 Gym Progress Tracker – Development Plan

Simple .NET MAUI mobile app for tracking gym exercises and saving progress locally.

## 🛠 Project Setup & Architecture

- [x] **GP-1 Create MAUI project**
  - [x] Create new .NET MAUI app (Android + iOS)
  - [x] Clean template files
  - [x] Setup folders: Models, Views, ViewModels, Services

- [x] **GP-2 Configure MVVM**
  - [x] Install CommunityToolkit.Mvvm
  - [x] Setup dependency injection
  - [x] Prepare base ViewModel

## 📦 Models & Data

- [x] **GP-3 Implement Exercise model**
  - [x] Name (string)
  - [x] RepsOrTime (string)
  - [x] Weight (string)

- [ ] **GP-4 Prepare data collection**
  - [ ] ObservableCollection<Exercise>
  - [ ] Basic mapping ready for JSON serialization

## 💾 Local Storage

- [ ] **GP-5 Implement JSON storage service**
  - [ ] Save/load from FileSystem.AppDataDirectory/exercises.json
  - [ ] LoadExercises()
  - [ ] SaveExercises()
  - [ ] AddExercise()
  - [ ] DeleteExercise()
  - [ ] Handle missing/corrupted file

## 🧭 Navigation & Pages

- [ ] **GP-6 Setup Shell navigation**
  - [ ] MainPage
  - [ ] ExerciseListPage
  - [ ] AddExercisePage

- [ ] **GP-7 Create pages**
  - [ ] Main screen
  - [ ] Exercise list screen
  - [ ] Add exercise screen

## 🏋️ Exercise List Feature

- [ ] **GP-8 Implement exercise list UI**
  - [ ] CollectionView displaying exercises
  - [ ] Show name, reps/time, weight
  - [ ] Delete button per row
  - [ ] Empty state message

- [ ] **GP-9 Implement ExerciseListViewModel**
  - [ ] Load exercises on open
  - [ ] Delete command
  - [ ] Refresh after changes

## ➕ Add Exercise Feature

- [ ] **GP-10 Implement add exercise UI**
  - [ ] Input fields: Name, Reps/Time, Weight
  - [ ] "+" Save button
  - [ ] "X" Cancel button
  - [ ] Row visible only when adding

- [ ] **GP-11 Implement add logic**
  - [ ] Validate inputs
  - [ ] Create Exercise
  - [ ] Save to storage
  - [ ] Navigate back to list

## 🎨 UI & UX Polish

- [ ] **GP-12 Basic styling**
  - [ ] Clean spacing/layout
  - [ ] Mobile friendly buttons
  - [ ] Light/dark compatible

- [ ] **GP-13 Feedback states**
  - [ ] Loading indicator
  - [ ] Validation messages
  - [ ] Empty list message

## 🧪 Testing & Stability

- [ ] **GP-14 Manual testing**
  - [ ] Add/delete exercises
  - [ ] App restart persistence
  - [ ] Multiple entries
  - [ ] Edge cases (empty/long input)